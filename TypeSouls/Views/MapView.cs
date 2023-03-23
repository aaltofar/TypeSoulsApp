using Spectre.Console;
using System.Reflection.Emit;
using TypeSouls.Data;

namespace TypeSouls.Views;
public class MapView
{
    private static Tree BuildMap(List<Area[]> allAreas)
    {
        var root = new Tree("[green]Lordran[/]");

        foreach (var t1 in allAreas)
        {
            var t = root.AddNode(t1[0].DecoratedName);

            foreach (var a in t1)
                if (!a.IsMajor)
                    t.AddNode(a.DecoratedName);
        }
        return root;
    }

    public static void MapScreen(List<Area[]> allAreas)
    {
        Console.Clear();
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

