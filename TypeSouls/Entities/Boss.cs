namespace TypeSouls.Entities;
public class Boss : IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsAlive { get; set; }
}

