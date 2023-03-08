using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using TypeSouls;
using TypeSouls.Screens;

Console.OutputEncoding = Encoding.UTF8;

GameLogic game = new GameLogic();
game.InitGame();
game.SaveGame();

//game.ContinueGame();

//game.testThis();
