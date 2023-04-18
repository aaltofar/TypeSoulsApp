using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TypeSouls;

public class GameService
{
    public Player ActivePlayer { get; set; }
    private const string SaveFileName = "saveFile.json";
    private bool HasContinue => File.Exists(SaveFileName);
    public List<Area[]> AllAreas { get; set; }
    private Random _r = new Random();

    public GameService()
    {
        PopulateAreaList();

    }

    public List<Area[]> PopulateAreaList()
    {
        AllAreas = new List<Area[]>
        {
            new Area[]
            {
                new("Firelink Shrine", true, true),
                new("New Londo Ruins", false, false),
                new("The Abyss", "Four Kings", false, false),
                new("Kiln of the First Flame", "Gwyn, Lord of Cinder", false, false, new List<string>(){"Dialog1", "Dialog2", "Dialog3"})
            },
            new Area[]
            {
                new("Undead Parish", true),
                new("New Londo Ruins", "Bell Gargoyles", false),
                new("Darkroot Garden", false),
                new("Darkroot Basin", "Hydra", false,new List<string>(){"Dialog1", "Dialog2", "Dialog3"}),
            },
            new Area[]
            {
                new("The Depths", true),
                new("Blighttown", false),
                new("Poison Swamp", false),
                new("Quelaag's Domain", "Chaos Witch Quelaag", false, new List < string >() { "Dialog1", "Dialog2", "Dialog3" }),
            },
            new Area[]
            {
                new("Sen's Fortress", "Iron Golem", true,new List<string>(){"Dialog1", "Dialog2", "Dialog3"}),
                new("Anor Londo", "Ornstein and Smough", false, new List < string >() { "Dialog1", "Dialog2", "Dialog3" }),
                new("The Dukes Archives", "Seath the Scaleless", false, new List < string >() { "Dialog1", "Dialog2", "Dialog3" }),
            },
        };

        return AllAreas;
    }

    public void InitGame()
    {
        ActivePlayer = new Player();
        ActivePlayer.CreateCharacter();
        ActivePlayer.Location = new Area("Firelink Shrine", false);

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
                    //VentureForth();
                    var adventure = new Adventure(ActivePlayer);
                    adventure.AdventureLoop();
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

