using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSouls.Data;
using TypeSouls.Entities;

namespace TypeSouls.Views;
internal class TravelMenu
{
    private static ConsoleKey _key;
    private List<string>? MenuChoices => MakeChoiceList();
    private List<Area[]> AllAreas { get; set; }
    private Player ActivePlayer { get; set; }

    public TravelMenu(List<Area[]> allAreas, Player activePlayer)
    {
        AllAreas = allAreas;
        ActivePlayer = activePlayer;
    }

    private List<string> MakeChoiceList()
    {
        var result = new List<string>();
        for (var i = 0; i < AllAreas.Count; i++)
            for (var j = 0; j < AllAreas[i].Length; j++)
                if (AllAreas[i][j].IsExplored)
                    result.Add(AllAreas[i][j].AreaName);

        return result;
    }

    private Tree BuildMap()
    {
        var tree = new Tree("[green]Lordran[/]");

        for (var i = 0; i < AllAreas.Count; i++)
        {
            var n = tree.AddNode(AllAreas[i][0].DecoratedName);
            for (var j = 0; j < AllAreas[i].Length; j++)
                if (!AllAreas[i][j].IsMajor)
                    n.AddNode(AllAreas[i][j].DecoratedName);
        }
        return tree;
    }

    public string MapScreen()
    {

        var destination = "";
        while (true)
        {
            Console.Clear();

            ConsoleSegments.MakeHeader("Where do you want to go?", $"Current location: {ActivePlayer.Location.AreaName}");
            Console.WriteLine();

            AnsiConsole.Write(BuildMap());

            MapLegend();

            (destination, _key) = ConsoleService.MakeArrowMenu(MenuChoices);

            if (_key is ConsoleKey.Enter or ConsoleKey.Backspace)
                break;

            Console.WriteLine();
        }

        return destination;
    }

    private static void MapLegend()
    {
        AnsiConsole.Markup($@"
*************************************************************************
Use [steelblue3]↑ ↓ Arrow keys[/] to select destination, confirm with [steelblue3]ENTER[/]
Press [steelblue3]BACKSPACE[/] to go back 
*************************************************************************");

    }
}
