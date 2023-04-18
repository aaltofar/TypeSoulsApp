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

    public Encounter()
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
    }

    private void InitTimer()
    {
        Timer.Reset();
        MyTimer.Stop();

        Timer.Start();
        MyTimer.Elapsed += myEvent;
        MyTimer.Interval = 50;
        MyTimer.Enabled = true;
        void myEvent(object source, ElapsedEventArgs e) => UpdateTimerAndCheckFail();
    }

    public void BossBattle()
    {
        Console.Clear();
        InitTimer();
    }

    private void ResetEncounterSameEnemy()
    {
        PlayerWinner = false;
        Word = AllWordsList[R.Next(AllWordsList.Count)].ToUpper();
        WrittenLetters = string.Empty;
        Console.Clear();
    }

    public bool PlayWordGame(Player activePlayer)
    {
        ResetEncounterSameEnemy();
        InitTimer();

        if (Timer.ElapsedMilliseconds < 5000)
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
                        break;
                    }

                    if (WrittenLetters != Word.ToUpper() || Timer.ElapsedMilliseconds >= 5000)
                        PlayerWinner = false;

                    PlayerWinner = WrittenLetters == Word;
                    inputKey = string.Empty;
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
        {
            activePlayer.TakeDamage(Opponent);
            FailScreen();
        }

        if (Opponent.CurrentHealth > 0)
            PlayWordGame(activePlayer);

        //WinScreen();
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
    }

    private void WinScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
        Console.Clear();

        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop);
        Console.WriteLine("You did it!");
        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop + 1);
        Console.WriteLine($"Defeated {Opponent.Name}");
        Thread.Sleep(2000);
    }
    private void DoDamageScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
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

