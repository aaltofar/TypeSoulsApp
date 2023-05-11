using Layout = TypeSouls.Views.Layout;

namespace TypeSouls.Combat;
internal class Adventure
{
    private const int MinLength = 5;
    private const int MaxLength = 12;
    public int AdventureLength { get; set; }
    public Player ActivePlayer { get; set; }
    public bool HasInvasion { get; set; }
    public Random R { get; set; }
    public Area NextArea { get; set; }
    public Adventure(Player activePlayer, Area nextArea)
    {
        ActivePlayer = activePlayer;
        R = new Random();
        AdventureLength = R.Next(1, 2);
        NextArea = nextArea;
        HasInvasion = ActivePlayer.Stats.Humanity && R.NextDouble() > 0.7;
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

            if (HasInvasion)
                InvasionFight();

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

    private void InvasionFight()
    {
        var invasionScreen = new Layout();
        var invader = new Invader();
        var invasionEncounter = new Encounter(ActivePlayer, invader);

        invasionScreen.MidMid = new List<string>()
        {
            "Moving deeper into the area, something senses your humanity",
            $"{invader.Name} comes for it, defend yourself!"
        };
        Console.Clear();
        ConsoleService.PrintLayout(invasionScreen);
        Thread.Sleep(5000);
        invasionEncounter.PlayWordGame();
        HasInvasion = false;
    }
}