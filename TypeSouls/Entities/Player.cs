using System.ComponentModel.Design;
using System.Data;
using System.Text.Json.Serialization;

namespace TypeSouls.Entities;
[Serializable]
public class Player : IEntity
{
    public int Level { get; set; }
    public string? Class { get; set; }
    public string? CharName { get; set; }
    public int CurrentExp { get; set; }
    [JsonIgnore]
    public double MaxExp => 100 * Math.Pow(1.1, Level - 1);
    public Area? Location { get; set; }
    public int MaxHealth => 50 + Stats.Endurance * 10;
    public int CurrentHealth { get; set; }
    public int StatPointsToPlace { get; set; }
    public PlayerStats Stats { get; set; }
    public int BossKills { get; set; }
    public int EstusAmount = 3;

    public Player()
    {
        Level = 1;
        Stats = new PlayerStats();
        CurrentHealth = MaxHealth;
        EstusAmount = 3;
    }

    public void CreateCharacter()
    {
        CharName = Views.CreateCharacter.NameCharacter();
        Class = Views.CreateCharacter.ChooseClass();

        switch (Class)
        {
            case "Warrior":
                Stats.Strength = 10;
                break;

            case "Knight":
                Stats.Endurance = 10;
                break;

            case "Sorcerer":
                Stats.Intellect = 10;
                break;

            case "Cleric":
                Stats.Faith = 10;
                break;

            case "Depraved":
                Stats.Endurance = 1;
                Stats.Faith = 1;
                Stats.Intellect = 1;
                Stats.Strength = 1;
                Level = 1;
                break;
        }
    }

    public void LevelUp()
    {
        Level++;
        StatPointsToPlace += 5;
        Stats.LevelUpAllStats(Class);
    }

    public void TakeDamage(bool isBoss)
    {
        if (isBoss)
            CurrentHealth -= 45;

        else
            CurrentHealth -= 25;
    }
    public string MakeHealthBar()
    {
        var result = "";
        for (var i = 0; i < CurrentHealth; i++)
        {
            if (i % 5 == 0)
                result += "█";

            if (CurrentHealth is > 0 and < 5)
                return "█";
        }

        return result;
    }

}

