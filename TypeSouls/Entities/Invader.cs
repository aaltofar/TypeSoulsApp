
namespace TypeSouls.Entities;
internal class Invader : IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    private List<string> AllNamesList { get; set; }
    public bool IsBoss { get; set; }
    public bool IsAlive { get; set; }
    private Random R { get; } = new Random();

    public Invader()
    {
        CurrentHealth = 100;
        AllNamesList = File.ReadLines(@"InvaderNames.txt").ToList();
        Name = AllNamesList[R.Next(AllNamesList.Count)];
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHealth - damage < 0)
        {
            CurrentHealth = 0;
            IsAlive = false;
            return;
        }

        CurrentHealth -= damage;
    }

    public string MakeHealthBar()
    {
        int missingHealth = (100 - CurrentHealth) / 5;

        string bar = new('█', CurrentHealth is > 0 and < 5 ? CurrentHealth / 5 + 1 : CurrentHealth / 5);
        string missingBar = new('█', missingHealth);

        return "[maroon]" + bar + "[/]" + "[silver]" + missingBar + "[/]";
    }

}

