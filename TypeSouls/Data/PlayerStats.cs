using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Data;

public class PlayerStats
{
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Endurance { get; set; }
    public int Faith { get; set; }
    public bool Humanity { get; set; }

    public PlayerStats()
    {
        Strength = 5;
        Intellect = 5;
        Endurance = 5;
        Faith = 5;
        Humanity = true;
    }

    public void LevelUpAllStats(string Class)
    {
        Strength++;
        Intellect++;
        Endurance++;
        Faith++;
        LevelEfficiencyStat(Class);
    }

    private void LevelEfficiencyStat(string Class)
    {
        switch (Class)
        {
            case "Warrior":
                Strength++;
                break;
            case "Knight":
                Endurance++;
                break;
            case "Cleric":
                Faith++;
                break;
            case "Sorcerer":
                Intellect++;
                break;
        }
    }

    //public void PlaceStatPoints(String stat)
    //{
    //    switch (stat)
    //    {
    //        case "Strength":

    //            break;
    //        case "Endurance":
    //            break;
    //        case "Intellect":
    //            break;
    //        case "Faith":
    //            break;
    //    }
    //}

    public (string, string)[] GetStatArray() => new[]
    {
            (nameof(Strength), Strength.ToString()),
            (nameof(Intellect), Intellect.ToString()),
            (nameof(Endurance), Endurance.ToString()),
            (nameof(Faith), Faith.ToString()),
            (nameof(Humanity), Humanity.ToString())
    };
}

