namespace TypeSouls.Combat;
internal class Adventure
{
    private const int MinLength = 5;
    private const int MaxLength = 12;
    public int AdventureLength { get; set; }
    public Player ActivePlayer { get; set; }
    public bool HasInvasion => ActivePlayer.Stats.Humanity && R.NextDouble() > 0.7;
    public Random R { get; set; }
    public Area NextArea { get; set; }
    public Adventure(Player activePlayer, Area nextArea)
    {
        ActivePlayer = activePlayer;
        R = new Random();
        AdventureLength = R.Next(1, 1);
        NextArea = nextArea;
    }

    public void AdventureLoop()
    {

        var battleCount = 0;
        Console.Clear();
        bool playerWinner = false;

        var lookAround = new LookAround(NextArea);
        lookAround.LookAroundScreen();

        while (battleCount < AdventureLength)
        {
            var encounter = new Encounter(ActivePlayer, new Enemy());
            encounter.PlayWordGame();

            var respite = new BriefRespiteScreen(ActivePlayer);
            var choice = respite.ShowRespiteScreen();

            if (choice == "Retreat")
                break;

            if (choice == "Drink Estus")
                ActivePlayer.DrinkEstus();

            battleCount++;
        }

        if (NextArea.AreaBoss is { IsAlive: true })
        {
            ConsoleService.BossDialoguePrompter(NextArea.AreaBoss);
            var bossEncounter = new Encounter(ActivePlayer, NextArea.AreaBoss);

            if (bossEncounter.PlayWordGame())
            {
                NextArea.AreaBoss.IsAlive = false;
                NextArea.IsExplored = true;
                ActivePlayer.Location = NextArea;
            }

        }
    }
}