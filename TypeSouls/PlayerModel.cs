using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls;
internal class PlayerModel
{
    public int Level { get; set; }
    public int CurrentExp { get; set; }
    public double MaxExp => 100 * Math.Pow(1.1, (Level - 1));
    public (MajorArea, SubArea) Location { get; set; }
    public int MaxHealth => 50 + (Stats.Endurance * 10);
    public int CurrentHealth { get; set; }
    public int StatPointsToPlace { get; set; }
    public PlayerStats Stats { get; set; }
    public int BossKills { get; set; }
    public bool Humanity { get; set; }

    public PlayerModel()
    {
        Level = 1;
        Stats = new PlayerStats();
        CurrentHealth = MaxHealth;
        Humanity = true;
    }

}

