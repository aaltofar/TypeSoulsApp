namespace TypeSouls.Views;
internal class StartMenuScreen
{
    public static string StartMenu(bool canContinue)
    {
        const string logo = @"[slowblink darkorange]                                                                          
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
        //var menuMusic = new CachedSound("menuMusic.wav");
        //AudioPlaybackEngine.Instance.PlaySound(menuMusic);
        var menuChoiceList = new List<MenuChoice>();

        if (canContinue)
            menuChoiceList.Add(new MenuChoice("Continue", "Continue your adventure"));

        menuChoiceList.Add(new MenuChoice("New Game", "Start a new adventure"));
        menuChoiceList.Add(new MenuChoice("GitHub", "View the source code on GitHub"));
        menuChoiceList.Add(new MenuChoice("Exit Game", "Exit the game"));

        while (true)
        {
            Console.Clear();
            ConsoleService.MakeHeader("Type Souls", "", Color.Orange3, "poison");
            Console.WriteLine();
            var (choice, key) = ConsoleService.MakeArrowMenu(menuChoiceList, "midMid");
            if (key == ConsoleKey.Enter)
                return choice;
        }
    }
}

