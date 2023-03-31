using System.Timers;
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
    private static bool IsDone { get; set; }
    private int CursorStartLeft { get; set; }
    private int CursorStartTop { get; set; }
    public Encounter()
    {
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
        Timer.Start();
        MyTimer.Elapsed += myEvent;
        MyTimer.Interval = 50;
        MyTimer.Enabled = true;
        void myEvent(object source, ElapsedEventArgs e) => UpdateTimerAndCheckFail();
    }

    public bool PlayWordGame()
    {
        InitTimer();

        while (Timer.ElapsedMilliseconds < 5000)
        {
            if (WrittenLetters.Length == Word.Length)
                return true;

            for (var i = 0; i < Word.Length; i++)
                if (WrittenLetters.Length != Word.Length)
                {
                    PrintWordAndProgress();
                    var inputKey = GetInput();

                    while (inputKey != Word[i].ToString())
                    {
                        FlashRed();
                        inputKey = GetInput();
                    }

                    if (inputKey == Word[i].ToString() && WrittenLetters.Length == Word.Length - 1)
                    {
                        WinScreen();
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
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop);
        Console.WriteLine("Your word is: ");
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 1);
        Console.WriteLine(Word);
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 2);
        Console.WriteLine(WrittenLetters);
    }

    private void UpdateTimerAndCheckFail()
    {
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 3);
        Console.Write(Timer.Elapsed.ToString(@"s\.ff") + " Seconds");
        Console.SetCursorPosition(CursorStartLeft, CursorStartTop + 2);
        if (Timer.ElapsedMilliseconds >= 5000)
            FailScreen();
    }

    private void FailScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ResetColor();
        Console.Clear();
        Console.SetCursorPosition(CursorStartLeft - 15, CursorStartTop);
        Console.WriteLine("You failed to write the word correctly in time");
        Console.SetCursorPosition(CursorStartLeft - 15, CursorStartTop + 1);
        Console.WriteLine($"{Opponent.Name} hit you for 69 damage");
        Console.ReadLine();
    }

    private void WinScreen()
    {
        Timer.Stop();
        MyTimer.Stop();
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ResetColor();
        Console.Clear();
        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop);
        Console.WriteLine("You did it!");
        Console.SetCursorPosition(CursorStartLeft - 7, CursorStartTop + 1);
        Console.WriteLine($"You hit {Opponent.Name} for 69 damage");
        Console.ReadLine();
    }

    private static string GetInput() => Console.ReadKey().KeyChar.ToString().ToUpper();
}

