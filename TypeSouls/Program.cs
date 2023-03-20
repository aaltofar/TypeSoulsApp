using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using TypeSouls;
using TypeSouls.Entities;
using TypeSouls.Views;

Console.OutputEncoding = Encoding.UTF8;
//AnsiConsole.Markup("[red]■■■■■■■■■■■■■■■■■■■■■■[/]");
var player = new Player();
GameService game = new GameService();
game.InitGame();
game.GameLoop();
//StartMenuScreen.StartMenu();
//ViewCharacter.ViewStats(player);
//game.InitGame();
//game.SaveGame();
//Map.MapScreen();
//BonfireMenu.BonfireScreen();
//game.ContinueGame();

//game.testThis();
