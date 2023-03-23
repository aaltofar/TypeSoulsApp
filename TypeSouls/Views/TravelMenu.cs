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
    private static Tree BuildMap(List<Area[]> allAreas)
    {
        var tree = new Tree("[green]Lordran[/]");

        for (int i = 0; i < allAreas.Count; i++)
        {
            var n = tree.AddNode(allAreas[i][0].DecoratedName);
            for (int j = 0; j < allAreas[i].Length; j++)
            {
                if (allAreas[i][j].IsExplored && !allAreas[i][j].IsMajor)
                    n.AddNode(allAreas[i][j].DecoratedName);

                if (!allAreas[i][j].IsExplored && !allAreas[i][j].IsMajor)
                {
                    n.AddNode(allAreas[i][j].DecoratedName);
                    return tree;
                }

                if (!allAreas[i][j].IsExplored)
                    return tree;

            }
        }


        //for (var i = 0; i < allAreas.Count; i++)
        //{
        //    var t1 = allAreas[i];
        //    var t = tree.AddNode(t1[0].DecoratedName);

        //    for (var j = 0; i < t1.Length; i++)
        //    {
        //        var a = t1[j];
        //        if (!allAreas[i][j + 1].IsExplored)
        //        {
        //            t.AddNode(allAreas[i][j].DecoratedName);
        //            return tree;
        //        }


        //        if (!allAreas[i][allAreas[i].Length - 1].IsExplored)
        //            return tree;

        //        if (!a.IsMajor)
        //            t.AddNode(a.DecoratedName);
        //    }
        //}


        //var tree = new Tree("[green]Lordran[/]");
        //int i = 0;
        //while (i < allAreas.Count)
        //{
        //    var n = tree.AddNode(allAreas[i][0].DecoratedName);

        //    foreach (var area in allAreas[i])
        //        if (!area.IsMajor)
        //            n.AddNode(area.DecoratedName);

        //    if (allAreas[i][allAreas[i].Length - 1].IsExplored)
        //        i++;

        //}
        return tree;
    }

    public static void MapScreen(List<Area[]> allAreas, Player player)
    {
        Console.Clear();
        ConsoleSegments.MakeHeader("Where do you want to go?", $"Current location: {player.Location.AreaName}");
        var lastKey = ConsoleKey.NoName;
        AnsiConsole.Write(BuildMap(allAreas));
        Console.WriteLine();
        AnsiConsole.Write("Press [L] to toggle legend or [BACKSPACE] to exit");
        Console.WriteLine();
        var key = Console.ReadKey(true).Key;

        while (key != ConsoleKey.Backspace)
        {
            if (key == ConsoleKey.L && key != lastKey)
            {
                Console.Clear();
                ConsoleSegments.MakeHeader("Where do you want to go?", $"Current location: {player.Location.AreaName}");
                AnsiConsole.Write(BuildMap(allAreas));
                Console.WriteLine();
                AnsiConsole.Write("Press [L] to toggle legend or [BACKSPACE] to exit");
                Console.WriteLine();
                MapLegend();
                key = Console.ReadKey(true).Key;
                lastKey = key;
            }
            else
            {
                Console.Clear();
                ConsoleSegments.MakeHeader("Where do you want to go?", $"Current location: {player.Location.AreaName}");
                AnsiConsole.Write(BuildMap(allAreas));
                Console.WriteLine();
                AnsiConsole.Write("Press [L] to toggle legend or [BACKSPACE] to exit");
                Console.WriteLine();
                key = Console.ReadKey(true).Key;
                lastKey = ConsoleKey.NoName;
            }
        }
    }

    private static void MapLegend()
    {
        Console.WriteLine();
        AnsiConsole.Markup(@"
******************************
*  [blue]Major Areas[/]               *
*  [wheat1]Area without a boss[/]       *
*  [orange1]Area with an alive boss[/]   *
*  [green]Area with a killed boss[/]   *
******************************");

    }
}
