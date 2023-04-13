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
    public List<MenuChoice> Choices { get; set; }

    public BriefRespiteScreen(Player activePlayer)
    {
        ActivePlayer = activePlayer;
        Choices = new List<MenuChoice>();
        FillChoiceList();
    }

    private void FillChoiceList()
    {
        if (ActivePlayer is { EstusAmount: > 0 })
            Choices.Add(new MenuChoice("Drink estus", "Replenishes health, removes a charge of estus on use"));

        Choices.Add(new MenuChoice("Continue", "Continue deeper into the unknown"));
        Choices.Add(new MenuChoice("Retreat", "Cowardly return to the previous bonfire. Your progress is NOT saved."));
    }

    public string ShowRespiteScreen()
    {
        while (true)
        {
            Console.Clear();
            ConsoleSegments.MakeHeader("Brief respite", "Estus left: " + ActivePlayer.EstusAmount.ToString());
            Console.WriteLine();
            var (choice, key) = ConsoleSegments.MakeArrowMenu(Choices, "top");
            if (key == ConsoleKey.Enter)
                return choice;
        }
    }
}