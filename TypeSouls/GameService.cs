using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TypeSouls.Areas;
using TypeSouls.Entities;
using TypeSouls.Views;

namespace TypeSouls;

public class GameService
{
    public Player ActivePlayer { get; set; }
    private String _saveFileName = "saveFile.json";
    private bool HasContinue => File.Exists(_saveFileName);
    public List<Area[]> AllAreas { get; set; }

    public GameService()
    {
        PopulateAreaList();
    }
    public List<Area[]> PopulateAreaList()
    {
        AllAreas = new()
        {
            new Area[]
            {
                new Area("Firelink Shrine", true),
                new Area("New Londo Ruins", false),
                new Area("The Abyss", "Four Kings", false),
                new Area("Kiln of the First Flame", "Gwyn, Lord of Cinder", false)
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
        ActivePlayer.Location = new Area("Firelink Shrine", true);
    }

    public void SaveGame()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string _jsonString = JsonSerializer.Serialize(ActivePlayer, options);
        File.WriteAllText(_saveFileName, _jsonString);
    }

    public void ContinueGame()
    {
        if (File.Exists(_saveFileName))
        {
            string jsonString = File.ReadAllText(_saveFileName);
            ActivePlayer = JsonSerializer.Deserialize<Player>(jsonString);
        }
    }

    public void GameLoop()
    {
        //Player always spawns at a bonfire
        //Bonfire menu to choose what happens next, Venture Forth = progress in major area
        //if area is beat and has nowhere to lead to player will be prompted to go back to firelink or progress to the next major area.
        //
        HandleMenuChoice(StartMenuScreen.StartMenu(HasContinue));
        do
        {
            var bonfireMenuChoice = new BonfireMenu(ActivePlayer.Location).BonfireScreen();

            switch (bonfireMenuChoice)
            {
                case "Travel":
                    break;
                case "Venture forth":
                    break;
                case "View map":
                    MapView.MapScreen(AllAreas);
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
    void HandleMenuChoice(string choice)
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
        ProcessStartInfo ps = new ProcessStartInfo
        {
            FileName = "https://github.com/aaltofar/TypeSoulsApp",
            UseShellExecute = true
        };
        Process.Start(ps);
    }
}

