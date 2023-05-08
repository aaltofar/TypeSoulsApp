namespace TypeSouls.Views;
public class LookAround
{
    public Layout LookAroundLayout { get; set; }
    public Area? CurrentArea { get; set; }

    public LookAround(Area area)
    {
        LookAroundLayout = new Layout();
        CurrentArea = area;
    }

    public void LookAroundScreen()
    {
        Console.Clear();

        ConsoleService.StringArraySplitter(CurrentArea);

        if (CurrentArea.AreaNpc is null)
            return;

        var choice = ConsoleService.TalkToNpcChoice();

        if (choice != "Talk")
            return;

        ConsoleService.DialoguePrompter(CurrentArea.AreaNpc);
    }
}

