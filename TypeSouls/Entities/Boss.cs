namespace TypeSouls.Entities;
public class Boss : IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }
    public bool IsAlive { get; set; }
    public List<string> DialogueList { get; set; }

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

    public void TakeDamage(int damage) => CurrentHealth -= damage;
}