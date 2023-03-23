using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSouls.Entities;

namespace TypeSouls.Views;
public static class ConsoleSegments
{
    public static void MakeHeader(string figTxt, string lineTxt)
    {
        Console.Clear();
        AnsiConsole.Write(
            new FigletText(figTxt).LeftJustified().Color(Color.DodgerBlue1));
        var divider = new Rule(lineTxt)
        {
            Justification = Justify.Left
        };
        AnsiConsole.Write(divider);
    }
}

