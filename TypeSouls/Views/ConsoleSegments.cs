using Spectre.Console;

namespace TypeSouls.Views;
public static class ConsoleSegments
{
    private static int _currentSelection;
    public static void MakeHeader(string? figTxt, string lineTxt)
    {
        Console.Clear();
        AnsiConsole.Write(
            new FigletText(figTxt).LeftJustified().Color(Color.SteelBlue3));
        var divider = new Rule(lineTxt)
        {
            Justification = Justify.Left
        };
        AnsiConsole.Write(divider);
    }
    public static void MakeFooter()
    {
        var divider = new Rule();
        Console.SetCursorPosition(0, Console.WindowHeight / 4 * 3);
        AnsiConsole.Write(divider);
        Console.ReadLine();
    }
    public static (string, ConsoleKey) MakeArrowMenu(List<string> choices, string position)
    {
        Console.CursorVisible = false;

        for (var i = 0; i < choices.Count; i++)
        {
            switch (position)
            {
                case "top": Console.SetCursorPosition(2, Console.WindowHeight / 8 + i); break;
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

