namespace TypeSouls.Combat;
internal class Adventure
{
    private const int MinLength = 5;
    private const int MaxLength = 12;
    public int AdventureLength { get; set; }
    public Player ActivePlayer { get; set; }
    public bool HasInvasion => ActivePlayer.Stats.Humanity && R.NextDouble() > 0.7;
    public Random R { get; set; }
    public Adventure(Player activePlayer)
    {
        ActivePlayer = activePlayer;
        R = new Random();
        AdventureLength = R.Next(MinLength, MaxLength);
    }

    public void AdventureLoop()
    {
        var battleCount = 0;
        Console.Clear();
        bool playerWinner = false;

        while (battleCount < AdventureLength)
        {
            var encounter = new Encounter(ActivePlayer);
            playerWinner = encounter.PlayWordGame();

            var respite = new BriefRespiteScreen(ActivePlayer);
            var choice = respite.ShowRespiteScreen();

            if (choice == "Retreat")
                break;

            if (choice == "Drink Estus")
                ActivePlayer.DrinkEstus();

            battleCount++;
        }

        if (ActivePlayer.Location.AreaBoss is { IsAlive: true })
        {
            var bossEncounter = new Encounter(ActivePlayer);

            if (bossEncounter.PlayWordGame())
            {
                ActivePlayer.Location.AreaBoss.IsAlive = false;
                ActivePlayer.Location.IsExplored = true;
            }

        }
    }
}