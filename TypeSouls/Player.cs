using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TypeSouls;
internal class Player
{
    public int Level { get; set; }
    public string Class { get; set; }
    public string CharName { get; set; }
    public int CurrentExp { get; set; }
    public double MaxExp => 100 * Math.Pow(1.1, (Level - 1));
    public (MajorArea, SubArea) Location { get; set; }
    public int MaxHealth => 50 + (Stats.Endurance * 10);
    public int CurrentHealth { get; set; }
    public int StatPointsToPlace { get; set; }
    public PlayerStats Stats { get; set; }
    public int BossKills { get; set; }
    public bool Humanity { get; set; }

    public Player()
    {
        Level = 1;
        Stats = new PlayerStats();
        CurrentHealth = MaxHealth;
        Humanity = true;
    }

}

