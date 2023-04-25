namespace TypeSouls.Views;
public class LookAround
{
    public Layout LookAroundLayout { get; set; }
    public Area? CurrentArea { get; set; }

    public LookAround(Area area)
    {
        CurrentArea = area;
    }

    public void MakeLookAroundView()
    {

    }
}

