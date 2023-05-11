namespace TypeSouls.Entities;
public class Boss : IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }
    public bool IsAlive { get; set; }
    public List<string> DialogueList { get; set; }

    public Boss()
    {

    }

    public Boss(string name)
    {
        Name = name;
        CurrentHealth = 100;
        IsBoss = true;
        IsAlive = true;
    }

    public Boss(string name, List<string> dialogue)
    {
        Name = name;
        DialogueList = dialogue;
        CurrentHealth = 100;
        IsBoss = true;
        IsAlive = true;
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