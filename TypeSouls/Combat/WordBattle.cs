using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
using TypeSouls.Entities;

namespace TypeSouls.Combat;
internal class WordBattle
{
    public IOpponent Opponent { get; set; }
    public Random R { get; set; }
    private List<string> AllWordsList { get; set; }
    private Stopwatch Timer { get; set; }
    private string Word { get; set; }
    private string WrittenLetters { get; set; }
    private Timer MyTimer { get; set; }
    public WordBattle()
    {
        Timer = new Stopwatch();
        WrittenLetters = string.Empty;
        AllWordsList = FillWordList();
        Word = DrawWord().ToUpper();
        R = new Random();
        MyTimer = new Timer();
    }

    private static List<string> FillWordList()
    {
        var result = new List<string>();
        foreach (string line in File.ReadLines(@"WordList.txt"))
            result.Add(line);
        return result;
    }

    private string DrawWord() => AllWordsList[R.Next(AllWordsList.Count)];

    private void InitTimer()
    {
        Timer.Start();

        MyTimer.Elapsed += myEvent;
        MyTimer.Interval = 250;
        MyTimer.Enabled = true;
        void myEvent(object source, ElapsedEventArgs e)
        {
            UpdateTimer();
        }
    }

    public bool PlayWordGame()
    {
        InitTimer();

        while (Timer.ElapsedMilliseconds < 4000)
        {
            if (WrittenLetters.Length == Word.Length)
                return true;

            for (var i = 0; i < Word.Length; i++)
                if (WrittenLetters.Length != Word.Length)
                {
                    PrintWordAndProgress();
                    var inputKey = GetInput();
                    if (Timer.ElapsedMilliseconds >= 4000)
                    {
                        MyTimer.Stop();
                        Timer.Stop();
                        Console.WriteLine("Womp womp");
                        return false;
                    }

                    while (inputKey != Word[i].ToString())
                    {
                        FlashRed();
                        inputKey = GetInput();
                    }

                    if (inputKey == Word[i].ToString() && WrittenLetters.Length == Word.Length - 1)
                    {
                        WrittenLetters += inputKey;
                        FlashGreen();
                        Timer.Stop();
                        MyTimer.Stop();
                        return true;
                    }

                    if (inputKey == Word[i].ToString())
                        WrittenLetters += inputKey;

                    PrintWordAndProgress();
                }
                else
                    break;

        }
        Timer.Stop();
        MyTimer.Stop();
        return false;
    }

    private void FlashGreen()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        PrintWordAndProgress();
        Console.ResetColor();
    }

    private void FlashRed()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        PrintWordAndProgress();
        Console.ResetColor();
    }

    private void PrintWordAndProgress()
    {
        Console.CursorLeft = Console.WindowWidth / 2;
        Console.CursorTop = Console.WindowHeight / 2;
        Console.WriteLine("Your word is: ");
        Console.CursorLeft = Console.WindowWidth / 2;
        Console.CursorTop = Console.WindowHeight / 2 + 1;
        Console.CursorLeft = Console.WindowWidth / 2;
        Console.WriteLine(Word);
        Console.CursorTop = Console.WindowHeight / 2 + 2;
        Console.CursorLeft = Console.WindowWidth / 2;
        Console.WriteLine(WrittenLetters);
    }

    private void UpdateTimer()
    {
        Console.CursorLeft = Console.WindowWidth / 2;
        Console.CursorTop = Console.WindowHeight / 2 + 3;
        Console.Write(Timer.Elapsed.ToString(@"s\.ff") + " Seconds");
    }

    private static string GetInput()
    {
        return Console.ReadKey().KeyChar.ToString().ToUpper();
    }
}

