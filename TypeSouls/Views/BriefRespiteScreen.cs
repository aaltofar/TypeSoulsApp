using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

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
        Console.Clear();
        ConsoleSegments.MakeHeader("Brief respite", "Health: " + ActivePlayer.CurrentHealth + ActivePlayer.MakeHealthBar() + "  |  Estus left: " + ActivePlayer.EstusAmount.ToString());

        var (choice, key) = ConsoleService.MakeArrowMenu(Choices, "mid");

        while (key != ConsoleKey.Enter)
        {
            Console.Clear();
            ConsoleSegments.MakeHeader("Brief respite", "Estus left: " + ActivePlayer.EstusAmount.ToString());
            Console.WriteLine();
            (choice, key) = ConsoleService.MakeArrowMenu(Choices, "top");
        }
        Console.Clear();
        return choice;
    }
}

