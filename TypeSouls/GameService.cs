using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TypeSouls;

public class GameService
{
    public Player ActivePlayer { get; set; }
    private const string SaveFileName = "saveFile.json";
    private bool HasContinue => File.Exists(SaveFileName);
    private List<NonPlayerCharacter>? NpcList => JsonSerializer.Deserialize<List<NonPlayerCharacter>>(File.ReadAllText("NPCs.json"));
    private List<Area>? AreaList => JsonSerializer.Deserialize<List<Area>>(File.ReadAllText("Areas.json"));
    public List<Area[]> AllAreas { get; set; }

    /*
    private List<Boss>? BossList => JsonSerializer.Deserialize<List<Boss>>(File.ReadAllText("Bosses.json"));
     */

    public GameService()
    {
        PopulateAreaList();
    }

    private Area GetArea(string areaName) => AreaList.FirstOrDefault(a => a.AreaName == areaName);
    //private Boss GetBoss(string bossName) => BossList.FirstOrDefault(b => b.Name == bossName);
    private NonPlayerCharacter FindNpcFromList(string name) => NpcList.FirstOrDefault(n => n.Name == name);

    public List<Area[]> PopulateAreaList()
    {
        AllAreas = new List<Area[]>
        {
            new[]
            {
                GetArea("Firelink Shrine"),
                GetArea("New Londo Ruins"),
                GetArea("The Abyss"),
                GetArea("Kiln of the First Flame")
            },
            new[]
            {   GetArea("Undead Burg"),
                GetArea("Undead Parish"),
                GetArea("Darkroot Garden"),
                GetArea("Darkroot Basin"),
            },
            new[]
            {   GetArea("The Depths"),
                GetArea("Blighttown"),
                GetArea("Poison Swamp"),
                GetArea("Quelaag's Domain"),
            },
            new[]
            {   GetArea("Sen's Fortress"),
                GetArea("Anor Londo"),
                GetArea("The Dukes Archives"),
            },
        };

        return AllAreas;
    }

    public void InitGame()
    {
        ActivePlayer = new Player();
        ActivePlayer.CreateCharacter();
        //ActivePlayer.Location = new Area("Undead Asylum", false, FindNpcFromList("Oscar, knight of Astora"));
        ActivePlayer.Location = GetArea("Firelink Shrine");
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
                    lookAround.LookAroundScreen();
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

    private bool IsNextArea(Area destination)
    {
        foreach (var aArray in AllAreas)
            for (var j = 0; j < aArray.Length; j++)
                if (ActivePlayer.Location.AreaName == aArray[j].AreaName && aArray[j + 1].AreaName == destination.AreaName)
                    return true;

        return false;
    }

    private bool CanTravel(Area destination) => destination.IsExplored || IsLastArea() || IsNextArea(destination);

    private bool IsLastArea()
    {
        foreach (var aArray in AllAreas)
            for (int j = 0; j < aArray.Length; j++)
                if (aArray[j].AreaName == ActivePlayer.Location.AreaName && j == aArray.Length - 1)
                    return true;

        return false;
    }

}

