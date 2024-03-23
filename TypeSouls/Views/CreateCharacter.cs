using Spectre.Console;
using TypeSouls.Audio;

namespace TypeSouls.Views;
internal static class CreateCharacter
{
    private static string?[] _classes = new[]
    {
        "Warrior",
        "Knight",
        "Cleric",
        "Sorcerer",
        "Depraved"
    };

    public static string? NameCharacter()
    {
        MakeHeader();
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 4);
        AnsiConsole.Markup("[dim orange1]What is your name?[/]");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 14, Console.WindowHeight / 2 + 5);
        AnsiConsole.Markup("[dim orange1]If you remember it that is...[/]");
        Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 3);
        var charName = Console.ReadLine();
        //MakeHeader();
        //Console.CursorVisible = false;
        //Console.SetCursorPosition(Console.WindowWidth / 2 - 23, Console.WindowHeight / 3);
        //AnsiConsole.Markup("[dim orange1]Well that's good... at least you know your own name...[/]");
        //Thread.Sleep(5000);
        return charName;
    }

    public static string? ChooseClass()
    {
        var startXMenu = Console.WindowWidth / 8 - 25;
        var startYMenu = Console.WindowHeight / 8 + 2;

        var startXStats = startXMenu + 20;
        var startYStats = Console.WindowHeight / 8;

        var startXDesc = Console.WindowWidth / 4;
        var startYDesc = Console.WindowHeight / 4 + 2;

        const int optionsPerLine = 1;
        const int spacingPerLine = 14;

        var currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            //Header and dividerline
            MakeHeader();
            Console.SetCursorPosition(startXStats, startYStats);
            AnsiConsole.Markup("[underline wheat1]Choose class:[/]");
            //Menu
            for (var i = 0; i < _classes.Length; i++)
            {
                Console.SetCursorPosition(startXMenu + i % optionsPerLine * spacingPerLine, startYMenu + i / optionsPerLine);

                if (i == currentSelection)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(">" + _classes[i]);
                }

                else
                    Console.Write(_classes[i]);

                Console.ResetColor();
            }

            switch (currentSelection)
            {
                case 0:
                    PrintWarriorInfo(startXStats, startYStats, startYDesc);
                    break;
                case 1:
                    PrintKnightInfo(startXStats, startYStats, startYDesc);
                    break;
                case 2:
                    PrintClericInfo(startXStats, startYStats, startYDesc);
                    break;
                case 3:
                    PrintSorcererInfo(startXStats, startYStats, startYDesc);
                    break;
                case 4:
                    PrintDepravedInfo(startXStats, startYStats, startYDesc);
                    break;
            }

            key = Console.ReadKey(true).Key;
            var menuMove = new CachedSound("move.wav");

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        AudioPlaybackEngine.Instance.PlaySound(menuMove);
                        if (currentSelection >= optionsPerLine)
                            currentSelection -= optionsPerLine;
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        AudioPlaybackEngine.Instance.PlaySound(menuMove);
                        if (currentSelection + optionsPerLine < _classes.Length)
                            currentSelection += optionsPerLine;
                        break;
                    }
            }
        } while (key != ConsoleKey.Enter);
        var menuSelect = new CachedSound("select.wav");
        Console.CursorVisible = true;
        AudioPlaybackEngine.Instance.PlaySound(menuSelect);
        return _classes[currentSelection];
    }

    private static void MakeHeader()
    {
        Console.Clear();
        AnsiConsole.Write(
            new FigletText("Create Character").Centered().Color(Color.Red));
        AnsiConsole.Write(new Rule());
    }

    private static void PrintDepravedInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 4 + 2;
        //DEPRAVED
        //Stats
        Console.SetCursorPosition(startXStats, startYStats);
        AnsiConsole.Markup(
            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
        Console.SetCursorPosition(startXStats, startYStats + 2);
        AnsiConsole.Markup("Strength 1    | [dim wheat1]increases damage done[/]");
        Console.SetCursorPosition(startXStats, startYStats + 4);
        AnsiConsole.Markup("Endurance 1   | [dim wheat1]increases your health[/]");
        Console.SetCursorPosition(startXStats, startYStats + 6);
        AnsiConsole.Markup(
            "Faith 1       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
        Console.SetCursorPosition(startXStats, startYStats + 8);
        AnsiConsole.Markup("Intellect 1   | [dim wheat1]increases time to type words in combat[/]");
        //Description
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Depraved start at level 4, with one point in each stat.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(
            "[wheat1]The ideal choice for those who want full control over their stat placement, at the cost of a more difficult start[/]");
    }

    private static void PrintSorcererInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 4 + 2;
        //SORCERER
        //Stats
        Console.SetCursorPosition(startXStats, startYStats);
        AnsiConsole.Markup(
            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
        Console.SetCursorPosition(startXStats, startYStats + 2);
        AnsiConsole.Markup("Strength 5    | [dim wheat1]increases damage done[/]");
        Console.SetCursorPosition(startXStats, startYStats + 4);
        AnsiConsole.Markup("Endurance 5   | [dim wheat1]increases your health[/]");
        Console.SetCursorPosition(startXStats, startYStats + 6);
        AnsiConsole.Markup(
            "Faith 5       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
        Console.SetCursorPosition(startXStats, startYStats + 8);
        AnsiConsole.Markup("[Green]Intellect 10[/]  | [dim wheat1]increases time to type words in combat[/]");
        //Description
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]A cunning and powerful mage who manipulates arcane forces.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Sorcerers use spells to deal damage, debuff, and control their enemies.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(
            "[wheat1]They are intelligent and ambitious and will stop at nothing to achieve their goals.[/]");
    }

    private static void PrintClericInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 4 + 2;
        //CLERIC
        //Stats
        Console.SetCursorPosition(startXStats, startYStats);
        AnsiConsole.Markup(
            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
        Console.SetCursorPosition(startXStats, startYStats + 2);
        AnsiConsole.Markup("Strength 5    | [dim wheat1]increases damage done[/]");
        Console.SetCursorPosition(startXStats, startYStats + 4);
        AnsiConsole.Markup("Endurance 5   | [dim wheat1]increases your health[/]");
        Console.SetCursorPosition(startXStats, startYStats + 6);
        AnsiConsole.Markup(
            "[Green]Faith 10     [/] | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
        Console.SetCursorPosition(startXStats, startYStats + 8);
        AnsiConsole.Markup("Intellect 5   | [dim wheat1]increases time to type words in combat[/]");
        //Description
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]A devout and compassionate healer who worships a higher power.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Clerics use holy magic to heal, buff, and protect their allies.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]A devout and compassionate healer who worships a higher power.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]They are kind and generous and will always help those in need.[/]");
    }

    private static void PrintKnightInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 4 + 2;
        //KNIGHT
        //Stats
        Console.SetCursorPosition(startXStats, startYStats);
        AnsiConsole.Markup(
            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
        Console.SetCursorPosition(startXStats, startYStats + 2);
        AnsiConsole.Markup("Strength 5    | [dim wheat1]increases damage done[/]");
        Console.SetCursorPosition(startXStats, startYStats + 4);
        AnsiConsole.Markup("[Green]Endurance 10[/]  | [dim wheat1]increases your health[/]");
        Console.SetCursorPosition(startXStats, startYStats + 6);
        AnsiConsole.Markup(
            "Faith 5       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
        Console.SetCursorPosition(startXStats, startYStats + 8);
        AnsiConsole.Markup("Intellect 5   | [dim wheat1]increases time to type words in combat[/]");
        //Description
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]A noble and loyal fighter who follows a code of honor and chivalry.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Knights usually use swords and shields to defend themselves and their allies.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Knights wear the heaviest armor and can resist magic and physical damage.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]They are loyal and courageous and will never abandon their comrades.[/]");
    }

    private static void PrintWarriorInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 4 + 2;
        //WARRIOR

        //Stats
        Console.SetCursorPosition(startXStats, startYStats);
        AnsiConsole.Markup(
            "[bold underline orange1]Stats:[/]        |[dim wheat1] Green highlight means this stat gains increased effectiveness for your class[/]");
        Console.SetCursorPosition(startXStats, startYStats + 2);
        AnsiConsole.Markup("[Green]Strength 10[/]   | [dim wheat1]increases damage done[/]");
        Console.SetCursorPosition(startXStats, startYStats + 4);
        AnsiConsole.Markup("Endurance 5   | [dim wheat1]increases your health[/]");
        Console.SetCursorPosition(startXStats, startYStats + 6);
        AnsiConsole.Markup(
            "Faith 5       | [dim wheat1]increases max health while not human, also gives you a chance to keep humanity when you die[/]");
        Console.SetCursorPosition(startXStats, startYStats + 8);
        AnsiConsole.Markup("Intellect 5   | [dim wheat1]increases time to type words in combat[/]");
        //Description
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]A brave and strong fighter who excels in melee combat.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(
            "[wheat1]Warriors use swords, axes, maces and other weapons to deal damage and excel in battle.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]They are versatile and can adapt to different situations on the battlefield.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
    }
}

