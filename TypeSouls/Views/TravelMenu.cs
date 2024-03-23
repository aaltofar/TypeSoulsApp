namespace TypeSouls.Views;
internal class TravelMenu
{
    private static ConsoleKey _key;
    private List<MenuChoice>? MenuChoices => MakeChoiceList();
    private List<Area[]> AllAreas { get; set; }
    private Player ActivePlayer { get; set; }

    public TravelMenu(List<Area[]> allAreas, Player activePlayer)
    {
        AllAreas = allAreas;
        ActivePlayer = activePlayer;
    }

    private List<MenuChoice> MakeChoiceList()
    {
        var result = new List<MenuChoice>();
        for (var i = 0; i < AllAreas.Count; i++)
            for (var j = 0; j < AllAreas[i].Length; j++)
                if (AllAreas[i][j].IsExplored)
                    result.Add(new MenuChoice(AllAreas[i][j].AreaName));

        return result;
    }

    private Tree BuildMap()
    {
        var tree = new Tree("[green]Lordran[/]");

        for (var i = 0; i < AllAreas.Count; i++)
        {
            var n = tree.AddNode(AllAreas[i][0].DecoratedName);
            for (var j = 0; j < AllAreas[i].Length; j++)
                if (!AllAreas[i][j].IsMajor)
                    n.AddNode(AllAreas[i][j].DecoratedName);
        }
        return tree;
    }

    public string MapScreen()
    {
        var selectedIndex = 0;
        var destination = "";
        ConsoleKey _key;
        while (true)
        {
            Console.Clear();

            ConsoleService.MakeHeader("Where do you want to go?", $"Current location: {ActivePlayer.Location.AreaName}", Color.Orange3);
            Console.WriteLine();

            //AnsiConsole.Write(BuildMap());

            //MapLegend();

            (destination, _key) = ConsoleService.MakeArrowMenu(MenuChoices, "midMid");

            if (_key is ConsoleKey.Enter or ConsoleKey.Backspace)
                break;

            Console.WriteLine();
        }

        return destination;
    }

    private static void MapLegend()
    {
        AnsiConsole.Markup($@"
*************************************************************************
Use [steelblue3]↑ ↓ Arrow keys[/] to select destination, confirm with [steelblue3]ENTER[/]
Press [steelblue3]BACKSPACE[/] to go back 
*************************************************************************");

    }
}
