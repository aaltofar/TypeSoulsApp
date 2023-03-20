using System;
using System.Collections.Generic;
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

    public void InitGame()
    {
        ActivePlayer = new Player();
        ActivePlayer.CreateCharacter();
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
                    MapView.MapScreen();
                    break;
                case "View Character":
                    ViewCharacter.ViewStats(ActivePlayer);
                    break;
                case "Level up":
                    break;
                case "Save and exit game":
                    break;
            }
        } while (true);

    }

}

