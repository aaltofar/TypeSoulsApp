using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls;
internal static class MovingScreen
{
    public static void CombatScreen()
    {
        var layout = new Layout("Root")
    .SplitRows(
        new Layout("Top").SplitColumns(
            new Layout("Left").SplitRows(new Layout("Text"), new Layout("Bars")),
            new Layout("Right").SplitRows(new Layout("enemyText"), new Layout("enemyBars"))),
        new Layout("Bottom").Ratio(5).SplitRows(new Layout("WordToWrite"), new Layout("TimerBar"), new Layout("OtherInfo")));

        var namePanel = new Panel(Align.Left(new Markup(@"Steve Cook
Lvl: 34
Class: Knight
Location: Undead Parish")));

        var barPanel = new Panel(new BarChart().Width(60).AddItem("Health", 100, Color.Red).AddItem("Exp", 20, Color.Yellow));

        var enemyNamePanel = new Panel(Align.Right(new Markup(@"
Hollow Warrior
Lvl: 33")));

        var enemyBarPanel = new Panel(Align.Right(new BarChart().Width(60).AddItem("Health", 100, Color.Red)));

        var timerBar = new BarChart().Width(100).AddItem(" ", 100, Color.Aquamarine1).Label("[blue bold underline]Time left[/]")
            .CenterLabel().ShowValues(false);

        var wordWrite = new Panel(Align.Center(new Markup(@"Your word is:
[green bold underline]PISTACHIO[/]")));
        wordWrite.Border = BoxBorder.None;
        var timer = new Panel(Align.Center(timerBar));
        var bottomInfo = new Panel(Align.Center(new Markup(@"
You have 6 more enemies left until you reach Darkroot Garden")));

        timer.Border = BoxBorder.None;
        enemyBarPanel.Border = BoxBorder.None;
        enemyNamePanel.Border = BoxBorder.None;
        barPanel.Border = BoxBorder.None;
        namePanel.Border = BoxBorder.None;
        bottomInfo.Border = BoxBorder.None;
        layout["OtherInfo"].Update(bottomInfo);
        layout["wordToWrite"].Update(wordWrite);
        layout["Text"].Update(namePanel);
        layout["Bars"].Update(barPanel);
        layout["enemyText"].Update(enemyNamePanel);
        layout["enemyBars"].Update(enemyBarPanel);
        layout["TimerBar"].Update(timer);

        AnsiConsole.Write(layout);

    }

}

