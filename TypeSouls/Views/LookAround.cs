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
        if (CurrentArea.AreaNpc is null)
            return;

        Console.Clear();
        ConsoleService.DialoguePrompter(CurrentArea.AreaNpc);

    }
}

