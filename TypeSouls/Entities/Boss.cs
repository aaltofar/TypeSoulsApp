namespace TypeSouls.Entities;
public class Boss : IOpponent
{
    public string Name { get; set; }
    public int Health { get; set; }
    public bool IsAlive { get; set; }
}

