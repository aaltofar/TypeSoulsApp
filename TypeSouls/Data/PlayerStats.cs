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

    public void LevelUpAllStats(string? @class)
    {
        Strength++;
        Intellect++;
        Endurance++;
        Faith++;
        LevelEfficiencyStat(@class);
    }

    private void LevelEfficiencyStat(string? @class)
    {
        switch (@class)
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

    public void PlaceStatPoints(string stat, int amountToIncrease)
    {
        switch (stat)
        {
            case "Strength":
                Strength += amountToIncrease;
                break;
            case "Endurance":
                Endurance += amountToIncrease;
                break;
            case "Intellect":
                Intellect += amountToIncrease;
                break;
            case "Faith":
                Faith += amountToIncrease;
                break;
        }
    }

    public (string, string)[] GetStatArray() => new[]
    {
            (nameof(Strength), Strength.ToString()),
            (nameof(Intellect), Intellect.ToString()),
            (nameof(Endurance), Endurance.ToString()),
            (nameof(Faith), Faith.ToString()),
            (nameof(Humanity), Humanity.ToString())
    };

}

