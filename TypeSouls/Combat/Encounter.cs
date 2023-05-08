using System.Timers;
using Layout = TypeSouls.Views.Layout;
using Timer = System.Timers.Timer;

namespace TypeSouls.Combat;
public class Encounter
{
    public IOpponent Opponent { get; set; }
    public Random R { get; set; }
    private List<string> AllWordsList { get; set; }
    private Stopwatch Timer { get; set; }
    private string Word { get; set; }
    private string WrittenLetters { get; set; }
    private Timer MyTimer { get; set; }
    private bool PlayerWinner { get; set; }
    private Player? ActivePlayer { get; set; }
    private Layout EncounterLayout { get; set; }
    private int CombatTimer { get; set; }

    public Encounter(Player activePlayer)
    {
        PlayerWinner = false;
        Opponent = new Enemy();
        Timer = new Stopwatch();
        R = new Random();
        WrittenLetters = string.Empty;
        AllWordsList = File.ReadLines(@"WordList.txt").ToList();
        Word = AllWordsList[R.Next(AllWordsList.Count)].ToUpper();
        MyTimer = new Timer();
        ActivePlayer = activePlayer;
        EncounterLayout = new Layout();
        CombatTimer = 5000 + ActivePlayer.Stats.Intellect * 100;
    }

    private void InitTimer()
    {
        Timer.Start();
        MyTimer.Start();
        MyTimer.Elapsed += MyEvent;
        MyTimer.Interval = 125;
        MyTimer.Enabled = true;
        void MyEvent(object source, ElapsedEventArgs e) => UpdateTimerAndCheckFail();
    }

    public void BossBattle()
    {
        Console.Clear();
        InitTimer();
    }

    private void ResetEncounter()
    {
        Timer.Reset();
        MyTimer.Stop();
        PlayerWinner = false;
        Word = AllWordsList[R.Next(AllWordsList.Count)].ToUpper();
        WrittenLetters = string.Empty;
        Console.Clear();
        EncounterLayout = new Layout();
    }

    public bool PlayWordGame()
    {
        ResetEncounter();
        InitTimer();

        for (var i = 0; i < Word.Length; i++)
        {
            if (WrittenLetters.Length != Word.Length)
            {
                EncounterView();

                var inputKey = GetInput();

                if (inputKey == Word[i].ToString())
                    WrittenLetters += inputKey;

                while (inputKey != Word[i].ToString())
                {
                    FlashRed();
                    inputKey = GetInput();
                    if (inputKey != Word[i].ToString())
                        continue;

                    WrittenLetters += inputKey;
                }

                PlayerWinner = WrittenLetters == Word.ToUpper();
            }
        }

        Timer.Stop();
        MyTimer.Stop();

        if (PlayerWinner)
        {
            Opponent.TakeDamage(ActivePlayer.DoDamage());
            DoDamageScreen();
        }
        else
            ActivePlayer.TakeDamage(Opponent);

        //if (activePlayer.CurrentHealth < 0)
        if (Opponent.IsAlive)
            PlayWordGame();

        WinScreen();

        return PlayerWinner;
    }

    private void FlashRed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        EncounterView();
        Console.ResetColor();
    }

    private void EncounterView()
    {
        EncounterLayout.LeftTop = new List<string>()
        {
            ActivePlayer.CharName + " " + "Level " + ActivePlayer.Level + " " + ActivePlayer.Class,
            ActivePlayer.MakeHealthBar(),
            "Health: " + ActivePlayer.CurrentHealth.ToString()
        };

        EncounterLayout.RightTop = new List<string>()
        {
            Opponent.Name,
            Opponent.MakeHealthBar(),
            "Health: " + Opponent.CurrentHealth.ToString()
        };

        EncounterLayout.MidMid = new List<string>()
        {
            "Your word is: ",
            Word,
            WrittenLetters,
            Timer.Elapsed.ToString(@"s\.ff") + " Seconds"
        };
        ConsoleService.PrintLayout(EncounterLayout);

        Console.CursorVisible = false;
        if (!Timer.IsRunning)
        {
            Timer.Start();
            MyTimer.Start();
        }
    }

    private void UpdateTimerAndCheckFail()
    {
        EncounterView();
        if (Timer.ElapsedMilliseconds >= CombatTimer)
        {
            PlayerWinner = false;
            FailScreen();
        }
    }

    private void FailScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
        EncounterLayout = new Layout();
        Console.Clear();
        EncounterLayout.MidMid = new List<string>()
        {
            "You failed to write the word correctly in time",
            $"{Opponent.Name} hit you for {ActivePlayer.TakeDamage(Opponent).ToString()} damage",
        };
        ConsoleService.PrintLayout(EncounterLayout);
        Thread.Sleep(2000);
        ResetEncounter();
    }

    private void WinScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
        EncounterLayout = new Layout();
        Console.Clear();
        EncounterLayout.MidMid = new List<string>()
        {
            "You did it!",
            $"Defeated {Opponent.Name}",
        };
        ConsoleService.PrintLayout(EncounterLayout);
        Thread.Sleep(2000);
    }

    private void DoDamageScreen()
    {
        Console.Clear();
        EncounterLayout = new Layout();
        EncounterLayout.MidMid = new List<string>()
        {
            "Success!",
            $"You hit {Opponent.Name} for {ActivePlayer.DoDamage().ToString()} damage",
            "",
        };

        if (Opponent.CurrentHealth < 0)
            EncounterLayout.MidMid.Add($"{Opponent.Name} perished");
        else
            EncounterLayout.MidMid.Add($"{Opponent.Name} has {Opponent.CurrentHealth} health left");

        ConsoleService.PrintLayout(EncounterLayout);
        Thread.Sleep(2000);
    }

    private static string GetInput() => Console.ReadKey().KeyChar.ToString().ToUpper();
}

