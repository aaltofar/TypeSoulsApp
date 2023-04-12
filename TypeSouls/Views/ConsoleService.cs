using Spectre.Console;
using TypeSouls.Audio;

namespace TypeSouls.Views;
public class ConsoleService
{
    private static int _currentSelection = 0;
    public static (string, ConsoleKey) MakeArrowMenu(List<string> choices, string position)
    {

        const int startXMenu = 2;
        var startYMenu = Console.WindowHeight / 2;

        Console.CursorVisible = false;

        for (var i = 0; i < choices.Count; i++)
        {
            //Console.SetCursorPosition(startXMenu, startYMenu + i);

            switch (position)
            {
                case "top": Console.SetCursorPosition(2, Console.WindowHeight / 3 + i); break;
                case "mid": Console.SetCursorPosition(2, Console.WindowHeight / 2 + i); break;
                case "bot": Console.SetCursorPosition(2, Console.WindowHeight / 4 * 3 + i); break;
            }

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