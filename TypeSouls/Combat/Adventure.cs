using NAudio.Codecs;

namespace TypeSouls.Combat;
internal class Adventure
{
    public int AdventureLength { get; set; }
    public Player ActivePlayer { get; set; }
    private List<Encounter> Encounters { get; set; }
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
        const int battleCount = 0;
        for (int i = 0; i < AdventureLength; i++)
            Encounters.Add(new Encounter());

        while (battleCount < AdventureLength)
        {

        }
    }

}

