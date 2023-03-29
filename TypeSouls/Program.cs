using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using TypeSouls;
using TypeSouls.Entities;
using TypeSouls.Views;

Console.OutputEncoding = Encoding.UTF8;

//Initializes logic and data
GameService game = new();

//Starts the game
game.GameLoop();
