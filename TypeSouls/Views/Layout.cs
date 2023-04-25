namespace TypeSouls.Views;
public class Layout
{
    public List<string>? LeftTop { get; set; }
    public List<string>? LeftMid { get; set; }
    public List<string>? LeftBot { get; set; }
    public List<string>? MidTop { get; set; }
    public List<string>? MidMid { get; set; }
    public List<string>? MidBot { get; set; }
    public List<string>? RightTop { get; set; }
    public List<string>? RightMid { get; set; }
    public List<string>? RightBot { get; set; }

    public List<List<string>?> GetModules()
    {
        return new List<List<string>?>()
        {
            LeftBot,
            LeftMid,
            LeftTop,
            MidBot,
            MidMid,
            MidTop,
            RightBot,
            RightMid,
            RightTop
        };
    }

    public void PrintLayout()
    {

    }

    //Dictionary<string, (int, int)>

}

