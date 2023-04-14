using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
public static class EncounterStartScreen
{
    public static void ShowEncounterStartScreen(Player player, IOpponent opponent)
    {
        ConsoleService.MakeHeader(opponent.Name, player.MakeHealthBar());
    }
}

