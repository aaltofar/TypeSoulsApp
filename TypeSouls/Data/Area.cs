﻿namespace TypeSouls.Data;

public class Area
{
    public string AreaName { get; set; }
    public string DecoratedName => DecorateName();
    public Boss? AreaBoss { get; set; }
    public bool IsMajor { get; set; }
    public bool IsExplored;
    public List<string>? AreaDescription { get; set; } = new List<string>();
    public NonPlayerCharacter? AreaNpc { get; set; }
    public bool SelectedForTravel { get; set; }


    public Area(string name, string bossName, bool isMajor, NonPlayerCharacter areaNpc)
    {
        AreaName = name;
        AreaBoss = new Boss(bossName);
        IsMajor = isMajor;
        AreaNpc = areaNpc;
    }

    public Area(string name, string bossName, bool isMajor, bool isExplored)
    {
        AreaName = name;
        AreaBoss = new Boss(bossName);
        IsMajor = isMajor;
        IsExplored = isExplored;
    }

    public Area(string name, string bossName, bool isMajor, bool isExplored, List<string> dialogue)
    {
        AreaName = name;
        AreaBoss = new Boss(bossName, dialogue);
        IsMajor = isMajor;
        IsExplored = isExplored;
    }

    public Area(string name, string bossName, bool isMajor, List<string> dialogue)
    {
        AreaName = name;
        AreaBoss = new Boss(bossName, dialogue);
        IsMajor = isMajor;
    }
    public Area(string name, string bossName, bool isMajor, List<string> dialogue, NonPlayerCharacter areaNpc)
    {
        AreaName = name;
        AreaBoss = new Boss(bossName, dialogue);
        IsMajor = isMajor;
        AreaNpc = areaNpc;
    }

    public Area(string name, bool isMajor)
    {
        AreaName = name;
        IsMajor = isMajor;
    }
    public Area(string name, bool isMajor, NonPlayerCharacter areaNpc)
    {
        AreaName = name;
        IsMajor = isMajor;
        AreaNpc = areaNpc;
    }

    public Area(string name, bool isMajor, bool isExplored)
    {
        AreaName = name;
        IsMajor = isMajor;
        IsExplored = isExplored;
    }
    public Area(string name, bool isMajor, bool isExplored, NonPlayerCharacter areaNpc)
    {
        AreaName = name;
        IsMajor = isMajor;
        IsExplored = isExplored;
        AreaNpc = areaNpc;
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

