using System.ComponentModel;
using System.Numerics;
using System.Timers;
using TypeSouls.Entities;
using Timer = System.Timers.Timer;

namespace TypeSouls.Combat;
public class Encounter : IDisposable
{
    public IOpponent Opponent { get; set; }
    public Random R { get; set; }
    private List<string> AllWordsList { get; set; }
    private Stopwatch Timer { get; set; }
    private string Word { get; set; }
    private string WrittenLetters { get; set; }
    private Timer MyTimer { get; set; }
    private int CursorStartLeft { get; set; }
    private int CursorStartTop { get; set; }
    private bool PlayerWinner { get; set; }
    private Player? ActivePlayer { get; set; }

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
        CursorStartLeft = Console.WindowWidth / 2;
        CursorStartTop = Console.WindowHeight / 2;
        ActivePlayer = activePlayer;
    }

    private void InitTimer()
    {
        Timer.Start();
        MyTimer.Start();
        MyTimer.Elapsed += myEvent;
        MyTimer.Interval = 125;
        MyTimer.Enabled = true;
        void myEvent(object source, ElapsedEventArgs e) => UpdateTimerAndCheckFail();
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
    }

    public bool PlayWordGame()
    {
        ResetEncounter();
        InitTimer();

        for (var i = 0; i < Word.Length; i++)
        {
            if (WrittenLetters.Length != Word.Length)
            {
                PrintWordAndProgress();

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
            Opponent.TakeDamage(51);
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

    //private void PrintAmbienceText()
    //{
    //    if (Opponent.IsBoss)
    //    {
    //    }
    //}

    private void FlashRed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        PrintWordAndProgress();
        Console.ResetColor();
    }

    private void PrintWordAndProgress()
    {
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop);
        Console.WriteLine("Your word is: ");
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 1);
        Console.WriteLine(Word);
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 2);
        Console.WriteLine(WrittenLetters);
        Console.CursorVisible = false;
        if (!Timer.IsRunning)
        {
            Timer.Start();
            MyTimer.Start();
        }
    }

    private void PrintHealthBars()
    {

    }

    private void UpdateTimerAndCheckFail()
    {
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 3);
        Console.Write(Timer.Elapsed.ToString(@"s\.ff") + " Seconds");
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 2);
        if (Timer.ElapsedMilliseconds >= 5000)
        {
            PlayerWinner = false;
            FailScreen();
        }
    }

    private void FailScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
        Console.Clear();

        Console.SetCursorPosition(CursorStartLeft - 15, CursorStartTop);
        Console.WriteLine("You failed to write the word correctly in time");
        Console.SetCursorPosition(CursorStartLeft - 15, CursorStartTop + 1);
        Console.WriteLine($"{Opponent.Name} hit you for 69 damage");
        Thread.Sleep(2000);
        ResetEncounter();
    }

    private void WinScreen()
    {
        Console.Clear();

        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop);
        Console.WriteLine("You did it!");
        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop + 1);
        Console.WriteLine($"Defeated {Opponent.Name}");
        Thread.Sleep(2000);
    }

    private void DoDamageScreen()
    {
        Console.Clear();

        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop);
        Console.WriteLine("Success!");
        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop + 1);
        Console.WriteLine($"You hit {Opponent.Name} for 69 damage");
        Thread.Sleep(2000);
    }

    private static string GetInput() => Console.ReadKey().KeyChar.ToString().ToUpper();

    public void Dispose() => GC.SuppressFinalize(this);

}

