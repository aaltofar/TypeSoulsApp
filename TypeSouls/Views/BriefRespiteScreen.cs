using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
internal static class BriefRespiteScreen
{
    private static List<string> choices = new()
    {
        "Continue",
        "Retreat"
    };

    public static string ShowRespiteScreen(Player activePlayer)
    {
        ConsoleSegments.MakeHeader("Brief respite", activePlayer.EstusAmount.ToString());
        Console.WriteLine();
        var (choice, key) = ConsoleService.MakeArrowMenu(choices);
        return choice;
    }
}

