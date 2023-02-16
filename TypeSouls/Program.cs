using System.Diagnostics;
using ShellProgressBar;
using Spectre.Console;
using System.IO;
using System.Text;
using TypeSouls;
using System.Timers;
using Timer = System.Timers.Timer;

Console.OutputEncoding = Encoding.UTF8;
PlayerModel player = new PlayerModel();

Random r = new Random();
////string logo = @"[slowblink darkorange]                                                                          
////@@@@@@@  @@@ @@@  @@@@@@@   @@@@@@@@      @@@@@@    @@@@@@   @@@  @@@  @@@        @@@@@@   
////@@@@@@@  @@@ @@@  @@@@@@@@  @@@@@@@@     @@@@@@@   @@@@@@@@  @@@  @@@  @@@       @@@@@@@   
////  @@!    @@! !@@  @@!  @@@  @@!          !@@       @@!  @@@  @@!  @@@  @@!       !@@       
////  !@!    !@! @!!  !@!  @!@  !@!          !@!       !@!  @!@  !@!  @!@  !@!       !@!       
////  @!!     !@!@!   @!@@!@!   @!!!:!       !!@@!!    @!@  !@!  @!@  !@!  @!!       !!@@!!    
////  !!!      @!!!   !!@!!!    !!!!!:        !!@!!!   !@!  !!!  !@!  !!!  !!!        !!@!!!   
////  !!:      !!:    !!:       !!:               !:!  !!:  !!!  !!:  !!!  !!:            !:!  
////  :!:      :!:    :!:       :!:              !:!   :!:  !:!  :!:  !:!   :!:          !:!   
////   ::       ::     ::        :: ::::     :::: ::   ::::: ::  ::::: ::   :: ::::  :::: ::   
////    :        :      :         :::::       :::::     :::::     ::::::     :::::    :::::
////[/]                                                                                      
////";

////var bonfireImage = @"
////[grey54]       ⠀⠀⢀⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣯⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⢺⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡏⣧⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢶⣿⣋⣟⠭⣿⣿⠟⠁⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣭⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡏⢮⣳⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡿⣦⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⠢⣽⣅⠀⠀[orange3 slowblink]⠀⠀⠀⠀⣀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡆⢤⣿⡇⠀⠀[orange3 slowblink]⠀⠀⣸⡟⠀⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢷⠸⣞⡇⠀[orange3 slowblink]⠀⠀⠀⡏⢧⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡄⣿⣷⠀⠀[orange3 slowblink]⠀⠀⢻⡈⢣⡀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⢸⣿⡆⠀[orange3 slowblink]⠀⠀⠀⢳⣬⣧⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡈⣿⣧⠀[orange3 slowblink]⠀⢠⡄⣸⣿⣿⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⢹⣿⡀⠀[orange3 slowblink]⢸⢧⠟⢹⠇⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠸⣿⡇[orange3 slowblink]⣠⠋⢾⣾⢸⢀⡀⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⠀⠀⢀⡖⠀[/]⠀⠸⣿⣶⣿[orange3 slowblink]⣷⡏⢰⡿⢿⠏⣸⡇⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⣿⡇⠀⣴⢋⣿⣿⣿⠇[/]⠀[orange3 slowblink]⡟⠁⣏⠀⣿⣧⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⣰⡞⣏⢦⠇⢸⡿⢿⠋[/]⠀[orange3 slowblink]⢀⣤⣀⡘⢦⡟⢸⣆⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⢹⣿⠃⢀⣴⡆[/][red1 rapidblink]⠀⠀⠈⣹⣿⡷⠆[/]⠀[orange3 slowblink]⠀⣧⠈⢿⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀
////⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⢠⠜⢁⡴⠋[/][red1 rapidblink]⡀⠙⢄⠀⣰⣿[/]⠀[orange3 slowblink]⣟⠓⠀⠀⢉⣴⠋⠀⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀
////⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⣤⢰⡏⡠⠊[/][red1 rapidblink]⡴⣇⠀⢀⡞⠉⠛[/]⠀[orange3 slowblink]⠀⡀⢀⣄⣩⠌⠙⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀[/]
////⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⠀⣸⣿⢣[/][red1 rapidblink]⠶⠖⠊⢀⣈⠉⣹⡷⢀⣴⡯⠔⣛⡵[/]⠀[orange3 slowblink]⠁⣠⡏⠸⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀[/]
////⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⢹⡿⢿⠟[/][red1 rapidblink]⠀⣰⡞⠉⣿⡷⠇⠃⣠⢴⣶⣾⡋⢀⡴⣽⠁[/]⠀[orange3 slowblink]⠀⠘⣏⣀⢰⣆⠀⠀⠀⠀⠀[/]
////⠀⠀[orange3 slowblink]⠀⠀⠀⣠⣶⣶⣅⣠⣶[/][red1 rapidblink]⠀⠒⠟⢁⡴⠋⠀⠀⠀⢹⣿⣿⡋⣧⢸⡇⡏⣀⣀[/]⠀[orange3 slowblink]⠀⠙⣿⣉⠙⢤⡄⠀⠀⠀[/]
////⠀[orange3 slowblink]⠀⣠⣴⣺⢿⣿⣿⡛⠛[/][red1 rapidblink]⠿⠿⣯⣷⡲⣶⣟⣻⡀⠀⣠⣿⣿⣖⣸⣨⣿⠿⠛[/]⠀[orange3 slowblink]⣻⣿⣶⣾⣾⠇⠀⠻⣄⠀⠀[/]
////[orange3 slowblink]⠀⣾⢟⠿⠿⢶⣮⡙⢏⢢⡀[/][red1 rapidblink]⢠⡌⣿⣿⡿⠟⡿⢳⣼⣿⣿⣿⣾⣿⣧⣤⣤[/]⠀[orange3 slowblink]⣤⣿⣿⣭⣿⠁⠀⠀⣀⣈⣧⠀[/]
////[orange3 slowblink]⢺⣥⢿⠾⠿⠿⠿⡿⠚⢋⣠⠯⣿⢉⢉⠻⠾⠛⢿⣿⠻⠿⢛⢋⣤⣯⣭⠽⠶⣾⣻⢿⣻⢿⠶⢛⣻⡿⢽⠄[/]
////";
////var choice = new SelectionPrompt<string>()
////        .AddChoices(new[] {
////            "Continue",
////            "New Game",
////            "GitHub",
////            "Exit Game"
////        });
////var choice2 = new SelectionPrompt<string>()
////    .AddChoices("Travel", "Level up", "View map", "Save game", "Save and exit game");
////var rule = new Rule("You reached Anor Londo");
////rule.LeftJustified();
////////Align.Center(new Markup(bonfireImage));
////AnsiConsole.Markup(bonfireImage);
////AnsiConsole.Write(rule);
////AnsiConsole.WriteLine();
////AnsiConsole.Prompt(choice2);

////AnsiConsole.Prompt(choice);
List<string> AllWordsList = new();
//var timerBar = new BarChart().Width(100).AddItem(" ", 100, Color.Aquamarine1).Label("[blue bold underline]Time left[/]")
//    .CenterLabel().ShowValues(false);

foreach (string line in File.ReadLines(@"WordList.txt"))
    AllWordsList.Add(line);
//int barLength = 100;
////testBar();

////async void testBar()
////{
////    for (int i = 20; i > 0; i--)
////    {

////        await Task.Delay(100);
////        AnsiConsole.Clear();
////        var timerBar = new BarChart().Width(barLength).AddItem(" ", barLength, Color.Aquamarine1).Label("[blue bold underline]Time left[/]")
////            .CenterLabel().ShowValues(false);
////        //Align.Center(timerBar);

////        AnsiConsole.Write(new Panel(Align.Center(timerBar)));
////        barLength -= 10;
////    }
////}
////Console.ReadLine();
////var pbar = new FixedDurationBar(new TimeSpan(200000000), "Initial message", ConsoleColor.Red);

////Console.ReadLine();
////await AnsiConsole.Progress()
////    .StartAsync(async ctx =>
////    {
////        var task1 = ctx.AddTask("[blue bold underline]Time left[/]");

////        while (!ctx.IsFinished)
////        {
////            await Task.Delay(200);
////            task1.Increment(5);
////        }
////    });
string DrawWord()
{
    return AllWordsList[r.Next(AllWordsList.Count)];
}
var word = DrawWord().ToUpper();
string writtenLetters = "";
Stopwatch timer = new Stopwatch();


PlayWordGame();



Console.ReadLine();

void PlayWordGame()
{
    timer.Start();
    var myTimer = new Timer();
    myTimer.Elapsed += myEvent;
    myTimer.Interval = 250;
    myTimer.Enabled = true;

    // Implement a call with the right signature for events going off
    void myEvent(object source, ElapsedEventArgs e)
    {
        UpdateTimer();
    }

    while (timer.ElapsedMilliseconds < 4000)
    {
        if (writtenLetters.Length == word.Length)
            break;

        for (var i = 0; i < word.Length; i++)
            if (writtenLetters.Length != word.Length)
            {
                PrintWordAndProgress();
                var inputKey = GetInput();
                if (timer.ElapsedMilliseconds >= 4000)
                {
                    myTimer.Stop();
                    timer.Stop();
                    Console.WriteLine("Womp womp");
                    break;
                }

                while (inputKey != word[i].ToString())
                {
                    FlashRed();
                    inputKey = GetInput();
                }

                if (inputKey == word[i].ToString() && writtenLetters.Length == word.Length - 1)
                {
                    writtenLetters += inputKey;
                    FlashGreen();
                    timer.Stop();
                    myTimer.Stop();
                    break;
                }

                if (inputKey == word[i].ToString())
                    writtenLetters += inputKey;

                PrintWordAndProgress();
            }
            else
                break;

    }
}

void FlashGreen()
{
    Console.ForegroundColor = ConsoleColor.Green;
    PrintWordAndProgress();
    Console.ResetColor();
}

void FlashRed()
{
    Console.ForegroundColor = ConsoleColor.Red;
    PrintWordAndProgress();
    Console.ResetColor();
}

void PrintWordAndProgress()
{
    Console.CursorLeft = Console.WindowWidth / 2;
    Console.CursorTop = Console.WindowHeight / 2;
    Console.WriteLine("Your word is: ");
    Console.CursorLeft = Console.WindowWidth / 2;
    Console.CursorTop = Console.WindowHeight / 2 + 1;
    Console.CursorLeft = Console.WindowWidth / 2;
    Console.WriteLine(word);
    Console.CursorTop = Console.WindowHeight / 2 + 2;
    Console.CursorLeft = Console.WindowWidth / 2;
    Console.WriteLine(writtenLetters);
}

void UpdateTimer()
{
    Console.CursorLeft = Console.WindowWidth / 2;
    Console.CursorTop = Console.WindowHeight / 2 + 3;
    Console.Write(timer.Elapsed.ToString(@"s\.ff") + " Seconds");
}
string GetInput()
{
    return Console.ReadKey().KeyChar.ToString().ToUpper();
}