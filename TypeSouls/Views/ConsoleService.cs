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
    private static int _currentSelection = 0;
    public static (string, ConsoleKey) MakeArrowMenu(List<string> choices)
    {

        const int startXMenu = 2;
        var startYMenu = Console.WindowHeight / 2;

        Console.CursorVisible = false;

        for (var i = 0; i < choices.Count; i++)
        {
            Console.SetCursorPosition(startXMenu, startYMenu + i);

            if (i == _currentSelection)
                AnsiConsole.Markup($">[steelblue3] {choices[i]}[/]");

            else
                Console.Write(choices[i]);
        }

        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                {
                    if (_currentSelection > 0)
                        _currentSelection--;
                    break;
                }
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                {
                    if (_currentSelection < choices.Count - 1)
                        _currentSelection++;

                    break;
                }
        }

        Console.CursorVisible = true;
        return (choices[_currentSelection], key);
    }
}