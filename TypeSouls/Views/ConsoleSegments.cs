using Spectre.Console;

namespace TypeSouls.Views;
public static class ConsoleSegments
{
    public static void MakeHeader(string figTxt, string lineTxt)
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
}

