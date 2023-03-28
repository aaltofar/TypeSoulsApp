using TypeSouls.Entities;

namespace TypeSouls.Data;

public class Area
{
    public string AreaName { get; set; }
    public string DecoratedName => DecorateName();
    public Boss? AreaBoss { get; set; }
    public bool IsMajor { get; set; }
    public bool IsExplored = false;
    public bool SelectedForTravel { get; set; }

    public Area(string name, string bossName, bool isMajor)
    {
        AreaName = name;
        AreaBoss = new Boss()
        {
            Name = bossName,
            IsAlive = true
        };
        IsMajor = isMajor;
    }
    public Area(string name, string bossName, bool isMajor, bool isExplored)
    {
        AreaName = name;
        AreaBoss = new Boss()
        {
            Name = bossName,
            IsAlive = true
        };
        IsMajor = isMajor;
        IsExplored = isExplored;
    }

    public Area(string name, bool isMajor)
    {
        AreaName = name;
        IsMajor = isMajor;
    }
    public Area(string name, bool isMajor, bool isExplored)
    {
        AreaName = name;
        IsMajor = isMajor;
        IsExplored = isExplored;
    }

    public Area()
    {

    }


    private string DecorateName()
    {
        if (!IsExplored)
            return "[grey]" + "***********" + "[/]";
        if (SelectedForTravel)
            return "[bold blue underline]" + AreaName + "[/][bold green] <- Travel here?[/]";
        if (IsMajor)
            return "[bold yellow1]" + AreaName + "[/]";
        if (AreaBoss == null)
            return "[wheat1]" + AreaName + "[/]";

        return AreaBoss.IsAlive ? "[orange1]" + AreaName + " ☠︎[/]" : "[green]" + AreaName + "[/]";
    }

}

