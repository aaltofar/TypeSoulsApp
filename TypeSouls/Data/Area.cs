using TypeSouls.Entities;

namespace TypeSouls.Data;

public class Area
{
    public string AreaName { get; set; }
    public string DecoratedName => DecorateName();
    public Boss? AreaBoss { get; set; }
    public bool IsMajor { get; set; }

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

    public Area(string name, bool isMajor)
    {
        AreaName = name;
        IsMajor = isMajor;
    }

    public Area()
    {

    }

    private string DecorateName()
    {
        if (IsMajor)
            return "[bold blue]" + AreaName + "[/]";
        if (AreaBoss == null)
            return "[wheat1]" + AreaName + "[/]";

        return AreaBoss.IsAlive ? "[orange1]" + AreaName + " ☠︎[/]" : "[green]" + AreaName + "[/]";
    }

}

