using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSouls.Audio;
using TypeSouls.Entities;

namespace TypeSouls.Views;
public class ConsoleService
{
    public static void MakeArrowMenu(List<string> choices)
    {
        var startXMenu = Console.WindowWidth / 8 - 25;
        var startYMenu = Console.WindowHeight / 8 + 2;

        const int optionsPerLine = 1;
        const int spacingPerLine = 14;

        var currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            for (var i = 0; i < choices.Count; i++)
            {
                Console.SetCursorPosition(startXMenu + i % optionsPerLine * spacingPerLine, startYMenu + i / optionsPerLine);

                if (i == currentSelection)
                    AnsiConsole.Markup($">[dodgerblue1] {choices[i]})");

                else
                    Console.Write(choices[i]);

            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        if (currentSelection >= optionsPerLine)
                            currentSelection -= optionsPerLine;
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        if (currentSelection + optionsPerLine < choices.Count)
                            currentSelection += optionsPerLine;
                        break;
                    }
            }
        } while (key != ConsoleKey.Backspace);
        Console.CursorVisible = true;
    }
}