namespace TypeSouls.Entities;
internal class Invader : IOpponent
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }
    public bool IsAlive { get; set; }

    public void TakeDamage(int damage) => CurrentHealth -= damage;

    public string MakeHealthBar() => new('█', CurrentHealth is > 0 and < 5 ? CurrentHealth / 5 + 1 : CurrentHealth / 5);

}

