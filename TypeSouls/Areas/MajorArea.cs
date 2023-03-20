namespace TypeSouls.Areas;

public class MajorArea : IArea
{
    public string AreaName { get; set; }
    public string DecoratedName { get; set; }
    public SubArea[] LeadsTo { get; set; }
    public string BossName { get; set; }

    public MajorArea(string name, string bossName, params SubArea[] subAreas)
    {
        AreaName = name;
        BossName = bossName;
        LeadsTo = subAreas;
        DecoratedName = "[bold blue]" + name + "[/]";
    }

    public MajorArea(string name, params SubArea[] subAreas)
    {
        AreaName = name;
        DecoratedName = "[bold blue]" + name + "[/]";
        LeadsTo = subAreas;
    }
}

