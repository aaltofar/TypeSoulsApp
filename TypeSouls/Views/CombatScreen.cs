using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
public class CombatScreen
{
    private Player ActivePlayer { get; set; }
    private IOpponent Opponent { get; set; }

    public CombatScreen(Player activePlayer, IOpponent opponent)
    {
        ActivePlayer = activePlayer;
        Opponent = opponent;
    }

    public void PrintCombatScreen()
    {

    }
}

