using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TypeSouls;

public class GameService
{
    public Player ActivePlayer { get; set; }
    private const string SaveFileName = "saveFile.json";
    private bool HasContinue => File.Exists(SaveFileName);
    public List<NonPlayerCharacter> NpcList => JsonSerializer.Deserialize<List<NonPlayerCharacter>>(File.ReadAllText("NPCs.json"));
    public List<Area[]> AllAreas { get; set; }
    private Random _r = new Random();

    public GameService()
    {
        PopulateAreaList();
    }

    private NonPlayerCharacter FindNpcFromList(string name) => NpcList.FirstOrDefault(n => n.Name == name);

    public List<Area[]> PopulateAreaList()
    {
        AllAreas = new List<Area[]>
        {
            new Area[]
            {
                new("Firelink Shrine", true, true,FindNpcFromList("Crestfallen Knight")),
                new("New Londo Ruins", false, false),
                new("The Abyss", "Four Kings", false, false),
                new("Kiln of the First Flame", "Gwyn, Lord of Cinder", false, false, new List<string>(){ "In the deepest depths of the Kiln the Lord of Cinder awaited you", "His crown full of soot, his skin charred and his eyes missing from the hollowing", "Inherit the fire, succeed Lord Gwyn"})
            },
            new Area[]
            {
                new("Undead Parish", true),
                new("New Londo Ruins", "Bell Gargoyles", false, FindNpcFromList("Solaire of Astora")),
                new("Darkroot Garden", false),
                new("Darkroot Basin", "Hydra", false,new List<string>{"At the deepest part of the basin a towering hydra.", "It's heads are almost too many to count, you see at least 20 of them", "Strike them down, never waver"}),
            },
            new Area[]
            {
                new("The Depths", true,FindNpcFromList("Knight Lautrec of Carim")),
                new("Blighttown", false),
                new("Poison Swamp", false),
                new("Quelaag's Domain", "Chaos Witch Quelaag", false, new List < string >() { "Quelaag, daughter of the Witch of Izalith who failed to escape the chaotic flame and was corrupted by it.", "Due to exposure to the flame, Quelaag mutated into spider-like creatures with their upper body being fused to the monsters' backs.", "Lay her to rest, ring the bell of awakening and succeed Lord Gwyn" }),
            },
            new Area[]
            {
                new("Sen's Fortress", "Iron Golem", true,new List<string>(){"Three times your height and made of iron on top of the fortress he stood", "Guarding the way forth, this giant must be felled"}),
                new("Anor Londo", "Ornstein and Smough", false, new List < string >() { "You enter the cathedral only to be met by two knights.", "Dragon Slayer Ornstein with his lance, and Executioner Smough with his large hammer", "So close to fulfilment of your destiny, surely they will not put and end to your journey" },FindNpcFromList("Gwynevere, Princess of Sunlight")),
                new("The Dukes Archives", "Seath the Scaleless", false, new List < string >() { "The room is filled with crystals, every inch glistening","The betrayer of all Dragonkind, awarded Dukedom for his devotion to Gwyn", "A prominent scholar, creator of sorcery, Seath might be the last thing that stands in your way" }),
            },
        };

        return AllAreas;
    }

    public void InitGame()
    {
        ActivePlayer = new Player();
        ActivePlayer.CreateCharacter();
        ActivePlayer.Location = AllAreas[0][0];
    }

    public void SaveGame()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(ActivePlayer, options);
        File.WriteAllText(SaveFileName, jsonString);
    }

    public void ContinueGame()
    {
        if (!File.Exists(SaveFileName)) return;
        var jsonString = File.ReadAllText(SaveFileName);
        ActivePlayer = JsonSerializer.Deserialize<Player>(jsonString);
    }

    public void GameLoop()
    {

        HandleMenuChoice(StartMenuScreen.StartMenu(HasContinue));
        do
        {
            var bonfireMenuChoice = new BonfireMenu(ActivePlayer.Location).BonfireScreen(IsLastArea(), ActivePlayer.StatPointsToPlace);

            switch (bonfireMenuChoice)
            {
                case "Travel":
                    var travelMenu = new TravelMenu(AllAreas, ActivePlayer);
                    travelMenu.MapScreen();
                    break;

                case "Venture forth":
                    var adventure = new Adventure(ActivePlayer);
                    adventure.AdventureLoop();
                    break;

                case "Look around":
                    var lookAround = new LookAround(ActivePlayer.Location);
                    lookAround.MakeLookAroundView();
                    break;

                case "View Character":
                    ViewCharacter.ViewStats(ActivePlayer);
                    break;

                case "Level up":
                    break;

                case "Save and exit game":
                    SaveGame();
                    Environment.Exit(69);
                    break;
            }
        } while (true);

    }

    public void VentureForth()
    {
        var destination = FindNextArea();

    }

    private Area FindNextArea()
    {
        Area nextArea = null;

        foreach (var aArray in AllAreas)
            for (int j = 0; j < aArray.Length; j++)
                if (aArray[j].AreaName == ActivePlayer.Location.AreaName && !IsLastArea())
                    nextArea = aArray[j + 1];

        return nextArea;
    }

    private void HandleMenuChoice(string choice)
    {
        switch (choice)
        {
            case "Continue":
                ContinueGame();
                break;

            case "New Game":
                InitGame();
                break;

            case "GitHub":
                OpenGitHub();
                break;

            case "Exit Game":
                Environment.Exit(1);
                break;
        }
    }

    public void OpenGitHub()
    {
        var ps = new ProcessStartInfo
        {
            FileName = "https://github.com/aaltofar/TypeSoulsApp",
            UseShellExecute = true
        };
        Process.Start(ps);
    }

    private void CalculateEncounters()
    {

    }

    private void Travel(bool hasCombat)
    {
        if (hasCombat)
            return;
    }

    private bool CanTravel(Area destination)
    {
        if (destination.IsExplored)
            return true;

        foreach (var aArray in AllAreas)
            for (var j = 0; j < aArray.Length; j++)
                if (ActivePlayer.Location.AreaName == aArray[j].AreaName && aArray[j + 1].AreaName == destination.AreaName)
                    return true;

        return false;
    }

    private bool IsLastArea()
    {
        foreach (var aArray in AllAreas)
            for (int j = 0; j < aArray.Length; j++)
                if (aArray[j].AreaName == ActivePlayer.Location.AreaName && j == aArray.Length - 1)
                    return true;

        return false;
    }

}

