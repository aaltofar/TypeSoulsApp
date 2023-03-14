using TypeSouls.Entities;

namespace TypeSouls.Areas;

public class SubArea
{
    public string AreaName { get; set; }
    public Boss? AreaBoss { get; set; }
    public string DecoratedName => DecorateName();

    public SubArea(string areaName, string bossName)
    {
        AreaName = areaName;
        AreaBoss = new Boss()
        {
            Name = bossName,
            IsAlive = true
        };
    }

    public SubArea(string areaName)
    {
        AreaName = areaName;
    }

    string DecorateName()
    {
        if (AreaBoss == null)
            return "[wheat1]" + AreaName + "[/]";

        return AreaBoss.IsAlive ? "[orange1]" + AreaName + " ☠︎[/]" : "[green]" + AreaName + "[/]";
    }
}
