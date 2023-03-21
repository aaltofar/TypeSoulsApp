using Spectre.Console;
using TypeSouls.Audio;

namespace TypeSouls.Views;
internal class StartMenuScreen
{

    public static string StartMenu(bool canContinue)
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
        var choiceList = new SelectionPrompt<string>();

        if (canContinue)
        {
            choiceList.AddChoices(new[] {
                "Continue",
                "New Game",
                "GitHub",
                "Exit Game"
            });
        }
        else
        {
            choiceList.AddChoices(new[] {
                "New Game",
                "GitHub",
                "Exit Game"
            });
        }

        var rule = new Rule("Type Souls v0.1");
        rule.Justification = Justify.Center;
        AnsiConsole.Markup(logo);
        AnsiConsole.WriteLine();
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();

        return AnsiConsole.Prompt(choiceList);
    }
}

