namespace TypeSouls.Entities;
public interface IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }
    public bool IsAlive { get; set; }

    public void TakeDamage(int damage);
    public string MakeHealthBar();

}

