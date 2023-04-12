using Spectre.Console;

namespace TypeSouls.Views;
public static class ConsoleSegments
{
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
    //string playerHealthBar, string opponentHealthBar
    public static void MakeFooter()
    {
        var divider = new Rule();
        Console.SetCursorPosition(0, Console.WindowHeight / 4 * 3);
        AnsiConsole.Write(divider);
        Console.ReadLine();
    }
}

