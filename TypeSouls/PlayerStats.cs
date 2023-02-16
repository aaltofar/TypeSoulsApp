using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls;
internal class PlayerStats
{
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Endurance { get; set; }
    public int Faith { get; set; }

    public PlayerStats()
    {
        Strength = 5;
        Intellect = 5;
        Endurance = 5;
        Faith = 5;
    }

    public void LevelUpAllStats()
    {
        Strength++;
        Intellect++;
        Endurance++;
        Faith++;
    }
}

