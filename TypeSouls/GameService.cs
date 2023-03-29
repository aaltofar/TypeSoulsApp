using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TypeSouls.Data;
using TypeSouls.Entities;
using TypeSouls.Views;

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
                new Area("Firelink Shrine", true, true),
                new Area("New Londo Ruins", false, false),
                new Area("The Abyss", "Four Kings", false, false),
                new Area("Kiln of the First Flame", "Gwyn, Lord of Cinder", false, false)
            },
            new Area[]
            {
                new Area("Undead Parish", true),
                new Area("New Londo Ruins", "Bell Gargoyles", false),
                new Area("Darkroot Garden", false),
                new Area("Darkroot Basin", "Hydra", false),
            },
            new Area[]
            {
                new Area("The Depths", true),
                new Area("Blighttown", false),
                new Area("Poison Swamp", false),
                new Area("Quelaag's Domain", "Chaos Witch Quelaag", false),
            },
            new Area[]
            {
                new Area("Sen's Fortress", "Iron Golem", true),
                new Area("Anor Londo", "Ornstein and Smough", false),
                new Area("The Dukes Archives", "Seath the Scaleless", false),
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
            var bonfireMenuChoice = new BonfireMenu(ActivePlayer.Location).BonfireScreen(IsLastArea());

            switch (bonfireMenuChoice)
            {
                case "Travel":
                    var travelMenu = new TravelMenu(AllAreas, ActivePlayer);
                    travelMenu.MapScreen();
                    break;

                case "Venture forth":
                    break;

                case "View Character":
                    ViewCharacter.ViewStats(ActivePlayer);
                    break;

                case "Level up":
                    break;

                case "Save and exit game":
                    SaveGame();
                    Environment.Exit(1);
                    break;
            }
        } while (true);

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

        foreach (var a in AllAreas)
            for (var j = 0; j < a.Length; j++)
                if (ActivePlayer.Location.AreaName == a[j].AreaName && a[j + 1].AreaName == destination.AreaName)
                    return true;

        return false;
    }

    private bool IsLastArea()
    {
        foreach (var a in AllAreas)
            for (int j = 0; j < a.Length; j++)
                if (a[j].AreaName == ActivePlayer.Location.AreaName && j == a.Length - 1)
                    return true;

        return false;
    }

}

