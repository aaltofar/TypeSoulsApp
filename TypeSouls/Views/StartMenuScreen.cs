using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Screens;
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

