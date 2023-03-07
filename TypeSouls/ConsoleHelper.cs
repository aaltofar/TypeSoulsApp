//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Spectre.Console;

//namespace TypeSouls;
//public static class ConsoleHelper
//{
//    public static string NameCharacter()
//    {
//        MakeHeader();
//        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 4);
//        AnsiConsole.Markup("[dim orange1]What is your name?[/]");
//        Console.SetCursorPosition(Console.WindowWidth / 2 - 14, Console.WindowHeight / 2 + 5);
//        AnsiConsole.Markup("[dim orange1]If you remember it that is...[/]");
//        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 3);
//        var charName = Console.ReadLine();
//        MakeHeader();
//        Console.CursorVisible = false;
//        Console.SetCursorPosition(Console.WindowWidth / 2 - 23, Console.WindowHeight / 3);
//        AnsiConsole.Markup("[dim orange1]Well that's good... at least you know your own name...[/]");
//        Thread.Sleep(5000);
//        return charName;
//    }
//    public static int ChooseClass(params string[] options)
//    {
//        int startXMenu = Console.WindowWidth / 8 - 25;
//        int startYMenu = Console.WindowHeight / 8 + 2;

//        int startXStats = startXMenu + 20;
//        int startYStats = Console.WindowHeight / 8;

//        int startXDesc = Console.WindowWidth / 4;
//        int startYDesc = Console.WindowHeight / 4 + 2;

//        const int optionsPerLine = 1;
//        const int spacingPerLine = 14;

//        int currentSelection = 0;

//        ConsoleKey key;

//        Console.CursorVisible = false;

//        do
//        {
//            //Header and dividerline
//            MakeHeader();
//            //Menu
//            for (var i = 0; i < options.Length; i++)
//            {
//                Console.SetCursorPosition(startXMenu + i % optionsPerLine * spacingPerLine, startYMenu + i / optionsPerLine);

//                if (i == currentSelection)
//                {
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.Write(">" + options[i]);
//                }

//                else
//                    Console.Write(options[i]);

//                Console.ResetColor();
//            }

//            switch (currentSelection)
//            {
//                case 0:
//                    PrintWarriorInfo(startXStats, out startYStats, out startYDesc);
//                    break;
//                case 1:
//                    PrintKnightInfo(startXStats, out startYStats, out startYDesc);
//                    break;
//                case 2:
//                    PrintClericInfo(startXStats, out startYStats, out startYDesc);
//                    break;
//                case 3:
//                    PrintSorcererInfo(startXStats, out startYStats, out startYDesc);
//                    break;
//                case 4:
//                    PrintDepravedInfo(startXStats, out startYStats, out startYDesc);
//                    break;
//            }

//            key = Console.ReadKey(true).Key;

//            switch (key)
//            {
//                case ConsoleKey.UpArrow:
//                    {
//                        if (currentSelection >= optionsPerLine)
//                            currentSelection -= optionsPerLine;
//                        break;
//                    }
//                case ConsoleKey.DownArrow:
//                    {
//                        if (currentSelection + optionsPerLine < options.Length)
//                            currentSelection += optionsPerLine;
//                        break;
//                    }
//            }
//        } while (key != ConsoleKey.Enter);

//        Console.CursorVisible = true;

//        return currentSelection;
//    }

//    private static void MakeHeader()
//    {
//        Console.Clear();
//        AnsiConsole.Write(
//            new FigletText("Create Character").Centered().Color(Color.Red));
//        AnsiConsole.Write(new Rule());
//    }

//    private static void PrintDepravedInfo(int startXStats, out int startYStats, out int startYDesc)
//    {
//        startYStats = Console.WindowHeight / 8;
//        startYDesc = Console.WindowHeight / 4 + 2;
//        //DEPRAVED
//        //Stats
//        Console.SetCursorPosition(startXStats, startYStats);
//        AnsiConsole.Markup(
//            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 2);
//        AnsiConsole.Markup("Strength 1    | [dim wheat1]increases damage done[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 4);
//        AnsiConsole.Markup("Endurance 1   | [dim wheat1]increases your health[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 6);
//        AnsiConsole.Markup(
//            "Faith 1       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 8);
//        AnsiConsole.Markup("Intellect 1   | [dim wheat1]increases time to type words in combat[/]");
//        //Description
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]Depraved start at level 4, with one point in each stat.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup(
//            "[wheat1]The ideal choice for those who want full control over their stat placement, at the cost of a more difficult start[/]");
//    }

//    private static void PrintSorcererInfo(int startXStats, out int startYStats, out int startYDesc)
//    {
//        startYStats = Console.WindowHeight / 8;
//        startYDesc = Console.WindowHeight / 4 + 2;
//        //SORCERER
//        //Stats
//        Console.SetCursorPosition(startXStats, startYStats);
//        AnsiConsole.Markup(
//            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 2);
//        AnsiConsole.Markup("Strength 5    | [dim wheat1]increases damage done[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 4);
//        AnsiConsole.Markup("Endurance 5   | [dim wheat1]increases your health[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 6);
//        AnsiConsole.Markup(
//            "Faith 5       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 8);
//        AnsiConsole.Markup("[Green]Intellect 10[/]  | [dim wheat1]increases time to type words in combat[/]");
//        //Description
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]A cunning and powerful mage who manipulates arcane forces.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]Sorcerers use spells to deal damage, debuff, and control their enemies.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup(
//            "[wheat1]They are intelligent and ambitious and will stop at nothing to achieve their goals.[/]");
//    }

//    private static void PrintClericInfo(int startXStats, out int startYStats, out int startYDesc)
//    {
//        startYStats = Console.WindowHeight / 8;
//        startYDesc = Console.WindowHeight / 4 + 2;
//        //CLERIC
//        //Stats
//        Console.SetCursorPosition(startXStats, startYStats);
//        AnsiConsole.Markup(
//            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 2);
//        AnsiConsole.Markup("Strength 5    | [dim wheat1]increases damage done[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 4);
//        AnsiConsole.Markup("Endurance 5   | [dim wheat1]increases your health[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 6);
//        AnsiConsole.Markup(
//            "[Green]Faith 10     [/] | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 8);
//        AnsiConsole.Markup("Intellect 5   | [dim wheat1]increases time to type words in combat[/]");
//        //Description
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]A devout and compassionate healer who worships a higher power.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]Clerics use holy magic to heal, buff, and protect their allies.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]A devout and compassionate healer who worships a higher power.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]They are kind and generous and will always help those in need.[/]");
//    }

//    private static void PrintKnightInfo(int startXStats, out int startYStats, out int startYDesc)
//    {
//        startYStats = Console.WindowHeight / 8;
//        startYDesc = Console.WindowHeight / 4 + 2;
//        //KNIGHT
//        //Stats
//        Console.SetCursorPosition(startXStats, startYStats);
//        AnsiConsole.Markup(
//            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 2);
//        AnsiConsole.Markup("Strength 5    | [dim wheat1]increases damage done[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 4);
//        AnsiConsole.Markup("[Green]Endurance 10[/]  | [dim wheat1]increases your health[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 6);
//        AnsiConsole.Markup(
//            "Faith 5       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 8);
//        AnsiConsole.Markup("Intellect 5   | [dim wheat1]increases time to type words in combat[/]");
//        //Description
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]A noble and loyal fighter who follows a code of honor and chivalry.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]Knights usually use swords and shields to defend themselves and their allies.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]Knights wear the heaviest armor and can resist magic and physical damage.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]They are loyal and courageous and will never abandon their comrades.[/]");
//    }

//    private static void PrintWarriorInfo(int startXStats, out int startYStats, out int startYDesc)
//    {
//        startYStats = Console.WindowHeight / 8;
//        startYDesc = Console.WindowHeight / 4 + 2;
//        //WARRIOR

//        //Stats
//        Console.SetCursorPosition(startXStats, startYStats);
//        AnsiConsole.Markup(
//            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 2);
//        AnsiConsole.Markup("[Green]Strength 10[/]   | [dim wheat1]increases damage done[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 4);
//        AnsiConsole.Markup("Endurance 5   | [dim wheat1]increases your health[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 6);
//        AnsiConsole.Markup(
//            "Faith 5       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
//        Console.SetCursorPosition(startXStats, startYStats + 8);
//        AnsiConsole.Markup("Intellect 5   | [dim wheat1]increases time to type words in combat[/]");
//        //Description
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]A brave and strong fighter who excels in melee combat.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup(
//            "[wheat1]Warriors use swords, axes, maces and other weapons to deal damage and excel in battle.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//        AnsiConsole.Markup("[wheat1]They are versatile and can adapt to different situations on the battlefield.[/]");
//        Console.SetCursorPosition(startXStats, startYDesc++);
//    }
//}

