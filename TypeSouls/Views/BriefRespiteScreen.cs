using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
public class BriefRespiteScreen
{
    public Player? ActivePlayer { get; set; }
    public List<string> Choices { get; set; }

    public BriefRespiteScreen(Player activePlayer)
    {
        ActivePlayer = activePlayer;
        Choices = new List<string>();
        FillChoiceList();
    }

    private void FillChoiceList()
    {
        if (ActivePlayer is { EstusAmount: > 0 })
            Choices.Add("Drink Estus");

        Choices.Add("Continue");
        Choices.Add("Retreat");
    }

    public string ShowRespiteScreen()
    {
        ConsoleSegments.MakeHeader("Brief respite", ActivePlayer.EstusAmount.ToString());
        Console.WriteLine();
        var (choice, key) = ConsoleService.MakeArrowMenu(Choices);

        while (key != ConsoleKey.Enter)
            (choice, key) = ConsoleService.MakeArrowMenu(Choices);

        return choice;
    }
}

