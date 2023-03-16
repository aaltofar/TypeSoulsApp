using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TypeSouls.Entities;

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

}

