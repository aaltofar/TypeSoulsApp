namespace TypeSouls.Entities;
internal class Invader : IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }

    public void TakeDamage(int damage) => CurrentHealth -= damage;

}

