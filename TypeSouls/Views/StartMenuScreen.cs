using Spectre.Console;
using TypeSouls.Audio;

namespace TypeSouls.Views;
internal class StartMenuScreen
{

    public static void StartMenu()
    {
        string logo = @"[slowblink darkorange]                                                                          
        @@@@@@@  @@@ @@@  @@@@@@@   @@@@@@@@      @@@@@@    @@@@@@   @@@  @@@  @@@        @@@@@@   
        @@@@@@@  @@@ @@@  @@@@@@@@  @@@@@@@@     @@@@@@@   @@@@@@@@  @@@  @@@  @@@       @@@@@@@   
          @@!    @@! !@@  @@!  @@@  @@!          !@@       @@!  @@@  @@!  @@@  @@!       !@@       
          !@!    !@! @!!  !@!  @!@  !@!          !@!       !@!  @!@  !@!  @!@  !@!       !@!       
          @!!     !@!@!   @!@@!@!   @!!!:!       !!@@!!    @!@  !@!  @!@  !@!  @!!       !!@@!!    
          !!!      @!!!   !!@!!!    !!!!!:        !!@!!!   !@!  !!!  !@!  !!!  !!!        !!@!!!   
          !!:      !!:    !!:       !!:               !:!  !!:  !!!  !!:  !!!  !!:            !:!  
          :!:      :!:    :!:       :!:              !:!   :!:  !:!  :!:  !:!   :!:          !:!   
           ::       ::     ::        :: ::::     :::: ::   ::::: ::  ::::: ::   :: ::::  :::: ::   
            :        :      :         :::::       :::::     :::::     ::::::     :::::    :::::
        [/]";
        var menuMusic = new CachedSound("menuMusic.wav");
        AudioPlaybackEngine.Instance.PlaySound(menuMusic);

        var choiceList = new SelectionPrompt<string>()
                .AddChoices(new[] {
                    "Continue",
                    "New Game",
                    "GitHub",
                    "Exit Game"
                });

        var rule = new Rule("Type Souls v0.1");
        rule.Justification = Justify.Center;
        AnsiConsole.Markup(logo);
        AnsiConsole.WriteLine();
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
        var choice = AnsiConsole.Prompt(choiceList);

        HandleMenuChoice(choice);
    }

    static void HandleMenuChoice(string choice)
    {
        switch (choice)
        {
            case "Continue":
                break;

            case "New Game":
                //CreateCharacterScreen.CreateCharacter();
                break;

            case "GitHub":
                //OpenGitHub();
                break;

            case "Exit Game":
                break;
        }
    }
}

