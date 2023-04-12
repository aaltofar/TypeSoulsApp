namespace TypeSouls.Entities;
public class Enemy : IOpponent, IEntity
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }
    private List<string> AllNamesList { get; set; }
    private Random R { get; } = new Random();

    public Enemy()
    {
        AllNamesList = File.ReadLines(@"EnemyList.txt").ToList();
        Name = AllNamesList[R.Next(AllNamesList.Count)];
        CurrentHealth = 100;
    }

    public void TakeDamage(int damage) => CurrentHealth -= damage;


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

