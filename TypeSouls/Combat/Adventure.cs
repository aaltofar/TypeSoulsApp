using NAudio.Codecs;

namespace TypeSouls.Combat;
internal class Adventure
{
    public int AdventureLength { get; set; }
    public Player ActivePlayer { get; set; }
    public bool HasInvasion => ActivePlayer.Stats.Humanity && R.NextDouble() > 0.7;
    public Random R { get; set; }
    public Adventure(Player activePlayer)
    {
        ActivePlayer = activePlayer;
        R = new Random();
        AdventureLength = R.Next(4, 12);
    }

    public void AdventureLoop()
    {
        var battleCount = 0;
        Console.Clear();
        while (battleCount < AdventureLength)
        {
            var encounter = new Encounter();
            using (encounter)
            {
                if (encounter.PlayWordGame())
                    encounter.Opponent.TakeDamage(ActivePlayer.DoDamage());
                else
                    ActivePlayer.TakeDamage(encounter.Opponent);

                var respite = new BriefRespiteScreen(ActivePlayer);
                var choice = respite.ShowRespiteScreen();
                if (choice == "Retreat")
                {
                    encounter.Dispose();
                    break;
                }

                if (choice == "Drink Estus")
                    ActivePlayer.DrinkEstus();

                battleCount++;
            }
        }
    }
}

