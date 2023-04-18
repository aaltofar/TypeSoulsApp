using System.Runtime.CompilerServices;

namespace TypeSouls.Views;
public static class ConsoleService
{
    private const int DefaultLeftPosition = 2;
    private static int _currentSelection;
    private static readonly int DefaultTopPosition = Console.WindowHeight / 8;
    private static readonly int DefaultMidPosition = Console.WindowHeight / 2;
    private static readonly int DefaultBotPosition = Console.WindowHeight / 4 * 3;
    private const int DefaultDescriptionVerticalPadding = 2;
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
        Console.SetCursorPosition(DefaultLeftPosition, DefaultBotPosition);
        AnsiConsole.Write(divider);
        Console.ReadLine();
    }

    public static (string, ConsoleKey) MakeArrowMenu(List<MenuChoice> choices, string position)
    {
        Console.CursorVisible = false;
        for (var i = 0; i < choices.Count; i++)
        {

            SetWritePosition(position, i, false, choices.Count);

            if (i == _currentSelection)
                AnsiConsole.Markup($">[steelblue3] {choices[i].ChoiceName}[/]");

            else
                Console.Write(choices[i].ChoiceName);

            SetWritePosition(position, i, true, choices.Count);
            if (i == _currentSelection)
            {
                for (int j = 0; j < choices[i].ChoiceDescription.Length; j++)
                    Console.Write("_");
                Console.WriteLine();
                AnsiConsole.Markup($"[wheat1]  {choices[i].ChoiceDescription}[/]");
            }
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
        return (choices[_currentSelection].ChoiceName, key);
    }

    private static void SetWritePosition(string position, int i, bool isDescription, int menuHeight)
    {
        switch (position)
        {
            case "top": Console.SetCursorPosition(DefaultLeftPosition, isDescription ? DefaultTopPosition + menuHeight + DefaultDescriptionVerticalPadding : DefaultTopPosition + i); break;
            case "mid": Console.SetCursorPosition(DefaultLeftPosition, isDescription ? DefaultMidPosition + menuHeight + DefaultDescriptionVerticalPadding : DefaultMidPosition + i); break;
            case "bot": Console.SetCursorPosition(DefaultLeftPosition, isDescription ? DefaultBotPosition + menuHeight + DefaultDescriptionVerticalPadding : DefaultBotPosition + i); break;
        }
    }

}