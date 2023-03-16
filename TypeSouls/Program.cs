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
//GameLogic game = new GameLogic();
//StartMenuScreen.StartMenu();
//game.InitGame();
//game.SaveGame();
//Map.MapScreen();
var player = new Player();
ViewCharacter.ViewStats(player);
//BonfireMenu.BonfireScreen();
//game.ContinueGame();

//game.testThis();
