using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSouls.Audio;
using TypeSouls.Entities;

namespace TypeSouls.Views;
internal class ViewCharacter
{
    public static string ViewStats(Player player)
    {
        int startXMenu = Console.WindowWidth / 8 - 25;
        int startYMenu = Console.WindowHeight / 8 + 2;

        int startXStats = startXMenu + 20;
        int startYStats = Console.WindowHeight / 8;

        int startXDesc = Console.WindowWidth / 4;
        int startYDesc = Console.WindowHeight / 4 + 2;

        const int optionsPerLine = 1;
        const int spacingPerLine = 14;

        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            //Header and dividerline
            MakeHeader(player);
            Console.SetCursorPosition(startXStats - 23, startYStats);
            AnsiConsole.Markup("[underline wheat1]Stat attributes:[/]");
            //Menu
            for (var i = 0; i < player.Stats.GetStatArray().Length; i++)
            {
                Console.SetCursorPosition(startXMenu + i % optionsPerLine * spacingPerLine, startYMenu + i / optionsPerLine);

                if (i == currentSelection)
                    AnsiConsole.Markup($">[dodgerblue1] {player.Stats.GetStatArray()[i].Item1}[/] ({player.Stats.GetStatArray()[i].Item2})");

                else
                    Console.Write($"{player.Stats.GetStatArray()[i].Item1} ({player.Stats.GetStatArray()[i].Item2})");

                Console.ResetColor();
            }

            switch (currentSelection)
            {
                case 0:
                    PrintStrengthInfo(startXStats, startYStats, startYDesc);
                    break;
                case 1:
                    PrintIntellectInfo(startXStats, startYStats, startYDesc);
                    break;
                case 2:
                    PrintEnduranceInfo(startXStats, startYStats, startYDesc);
                    break;
                case 3:
                    PrintFaithInfo(startXStats, startYStats, startYDesc);
                    break;
                case 4:
                    PrintHumanityInfo(startXStats, startYStats, startYDesc);
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
                        if (currentSelection + optionsPerLine < player.Stats.GetStatArray().Length)
                            currentSelection += optionsPerLine;
                        break;
                    }
            }
        } while (key != ConsoleKey.Enter);
        var menuSelect = new CachedSound("select.wav");
        Console.CursorVisible = true;

        AudioPlaybackEngine.Instance.PlaySound(menuSelect);
        return player.Stats.GetStatArray()[currentSelection].Item1;
    }

    private static void MakeHeader(Player player)
    {
        Console.Clear();
        AnsiConsole.Write(
            new FigletText(player.CharName).LeftJustified().Color(Color.DodgerBlue1));
        var divider = new Rule($"Level {player.Level} {player.Class}")
        {
            Justification = Justify.Left
        };
        AnsiConsole.Write(divider);
    }

    private static void PrintStrengthInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 8 + 2;

        Console.SetCursorPosition(startXStats, startYStats);

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Increases the damage done by the player.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(" ");
        AnsiConsole.Markup("[wheat1]“The power of the sun… In the palm of my hand!”[/]");

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1 dim] - Solaire of Astora[/]");
    }

    private static void PrintIntellectInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 8 + 2;

        Console.SetCursorPosition(startXStats, startYStats);

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Increases the player’s time in combat.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(" ");
        AnsiConsole.Markup("[wheat1]“The mind is everything. Without it, we are nothing.”[/]");

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1 dim] - Kingseeker Frampt[/]");
    }

    private static void PrintEnduranceInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 8 + 2;

        Console.SetCursorPosition(startXStats, startYStats);

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Increases the player’s health.[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(" ");
        AnsiConsole.Markup("[wheat1]“We Unkindled are worthless, can't even die right.”[/]");

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1 dim] - Hawkwood, the Deserter[/]");
    }

    private static void PrintFaithInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 8 + 2;

        Console.SetCursorPosition(startXStats, startYStats);

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]Makes the player sometimes keep humanity on death. [/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(" ");
        AnsiConsole.Markup("[wheat1]“The sun is a wondrous body like a magnificent father!”[/]");

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1 dim] - Solaire of Astora[/]");
    }

    private static void PrintHumanityInfo(int startXStats, int startYStats, int startYDesc)
    {
        startYStats = Console.WindowHeight / 8;
        startYDesc = Console.WindowHeight / 8 + 2;

        Console.SetCursorPosition(startXStats, startYStats);

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1]If your humanity is intact you are open to invasions, while if it has gone you have reduced maximum health[/]");
        Console.SetCursorPosition(startXStats, startYDesc++);
        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup(" ");
        AnsiConsole.Markup("[wheat1]“Death is equitable, accepting. We will all, one day, be welcomed by her embrace.”[/]");

        Console.SetCursorPosition(startXStats, startYDesc++);
        AnsiConsole.Markup("[wheat1 dim] - Grave Warden Agdayne[/]");
    }
}

