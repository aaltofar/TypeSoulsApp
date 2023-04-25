using System.ComponentModel.Design;
using System.Data;
using System.Reflection.Metadata.Ecma335;
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
    public int EstusAmount { get; set; }

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

    private void LevelUp()
    {
        Level++;
        StatPointsToPlace += 5;
        Stats.LevelUpAllStats(Class);
    }

    public void TakeDamage(IOpponent opponent) => CurrentHealth -= opponent is Boss ? 45 : 25;


    public string MakeHealthBar()
    {
        int missingHealth = (MaxHealth - CurrentHealth) / 5;

        string bar = new('█', CurrentHealth is > 0 and < 5 ? CurrentHealth / 5 + 1 : CurrentHealth / 5);
        string missingBar = new('█', missingHealth);

        return "[maroon]" + bar + "[/]" + "[silver]" + missingBar + "[/]";
    }

    public int DoDamage()
    {
        return 25;
    }

    public void DrinkEstus()
    {
        CurrentHealth = MaxHealth;
        EstusAmount--;
    }

    public void GiveExp(IOpponent opponent)
    {
        if (opponent is Boss or Invader)
            CurrentExp += 100;
        else
            CurrentExp += 50;

        if (CurrentExp >= MaxExp)
            LevelUp();
    }
}

