using Spectre.Console;
using System.Reflection.Emit;
using TypeSouls.Areas;

namespace TypeSouls.Views;
public class Map
{
    public static Tree DrawMap()
    {
        var root = new Tree("[green]World Map[/]");

        List<MajorArea> allAreas = new();

        var FirelinkShrine = new MajorArea("Firelink Shrine", new SubArea[]
        {
            new SubArea("New Londo Ruins"),
            new SubArea("The Abyss", "Four Kings"),
            new SubArea("Kiln of the First Flame", "Gwyn, Lord of Cinder")
        });

        var Depths = new MajorArea("The Depths", new SubArea[]
        {
            new SubArea("Blighttown"),
            new SubArea("Poison Swamp"),
            new SubArea("Quelaag's Domain", "Chaos Witch Quelaag")
        });

        var UndeadParish = new MajorArea("Undead Parish", new SubArea[]
        {
            new SubArea("New Londo Ruins", "Bell Gargoyles"),
            new SubArea("Darkroot Garden"),
            new SubArea("Darkroot Basin", "Hydra")
        });

        var SensFortress = new MajorArea("Sen's Fortress", "Iron Golem", new SubArea[]
        {
            new SubArea("Anor Londo", "Ornstein and Smough"),
            new SubArea("The Dukes Archives", "Seath the Scaleless")
        });

        allAreas.Add(FirelinkShrine);
        allAreas.Add(Depths);
        allAreas.Add(UndeadParish);
        allAreas.Add(SensFortress);

        for (int i = 0; i < allAreas.Count; i++)
        {
            var aToAdd = allAreas[i];
            var a = root.AddNode(aToAdd.DecoratedName);

            foreach (var s in aToAdd.LeadsTo)
                a.AddNode(s.DecoratedName);
        }

        //AnsiConsole.Write(root);
        //MapLegend();
        //AnsiConsole.Write("Press [L] to toggle legend");
        return root;
    }

    public static void MapScreen()
    {
        ConsoleKey lastKey = ConsoleKey.NoName;
        AnsiConsole.Write(DrawMap());
        Console.WriteLine();
        AnsiConsole.Write("Press [L] to toggle legend or [BACKSPACE] to exit");
        Console.WriteLine();
        var key = Console.ReadKey(true).Key;

        while (key != ConsoleKey.Backspace)
        {
            if (key == ConsoleKey.L && key != lastKey)
            {
                Console.Clear();
                AnsiConsole.Write(DrawMap());
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
                AnsiConsole.Write(DrawMap());
                Console.WriteLine();
                AnsiConsole.Write("Press [L] to toggle legend or [BACKSPACE] to exit");
                Console.WriteLine();
                key = Console.ReadKey(true).Key;
                lastKey = ConsoleKey.NoName;
            }
        }
    }

    static void MapLegend()
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

