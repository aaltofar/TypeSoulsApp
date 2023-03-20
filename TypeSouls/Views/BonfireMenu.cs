using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSouls.Areas;

namespace TypeSouls.Views;
public class BonfireMenu
{
    public IArea Area { get; init; }

    public BonfireMenu(IArea area)
    {
        Area = area;
    }

    static readonly string BonfireImage = @"
            [grey54]       ⠀⠀⢀⣤⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣯⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⢺⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡏⣧⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢶⣿⣋⣟⠭⣿⣿⠟⠁⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣭⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡏⢮⣳⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡿⣦⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⠢⣽⣅⠀⠀[orange3 slowblink]⠀⠀⠀⠀⣀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡆⢤⣿⡇⠀⠀[orange3 slowblink]⠀⠀⣸⡟⠀⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢷⠸⣞⡇⠀[orange3 slowblink]⠀⠀⠀⡏⢧⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡄⣿⣷⠀⠀[orange3 slowblink]⠀⠀⢻⡈⢣⡀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⢸⣿⡆⠀[orange3 slowblink]⠀⠀⠀⢳⣬⣧⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡈⣿⣧⠀[orange3 slowblink]⠀⢠⡄⣸⣿⣿⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⢹⣿⡀⠀[orange3 slowblink]⢸⢧⠟⢹⠇⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠸⣿⡇[orange3 slowblink]⣠⠋⢾⣾⢸⢀⡀⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⠀⠀⢀⡖⠀[/]⠀⠸⣿⣶⣿[orange3 slowblink]⣷⡏⢰⡿⢿⠏⣸⡇⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⣿⡇⠀⣴⢋⣿⣿⣿⠇[/]⠀[orange3 slowblink]⡟⠁⣏⠀⣿⣧⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⣰⡞⣏⢦⠇⢸⡿⢿⠋[/]⠀[orange3 slowblink]⢀⣤⣀⡘⢦⡟⢸⣆⠀[/]⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⢹⣿⠃⢀⣴⡆[/][red1 rapidblink]⠀⠀⠈⣹⣿⡷⠆[/]⠀[orange3 slowblink]⠀⣧⠈⢿⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⢠⠜⢁⡴⠋[/][red1 rapidblink]⡀⠙⢄⠀⣰⣿[/]⠀[orange3 slowblink]⣟⠓⠀⠀⢉⣴⠋⠀⠀⠀⠀⠀⠀[/]⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⣤⢰⡏⡠⠊[/][red1 rapidblink]⡴⣇⠀⢀⡞⠉⠛[/]⠀[orange3 slowblink]⠀⡀⢀⣄⣩⠌⠙⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀[/]
            ⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⠀⣸⣿⢣[/][red1 rapidblink]⠶⠖⠊⢀⣈⠉⣹⡷⢀⣴⡯⠔⣛⡵[/]⠀[orange3 slowblink]⠁⣠⡏⠸⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀[/]
            ⠀⠀⠀[orange3 slowblink]⠀⠀⠀⠀⠀⢹⡿⢿⠟[/][red1 rapidblink]⠀⣰⡞⠉⣿⡷⠇⠃⣠⢴⣶⣾⡋⢀⡴⣽⠁[/]⠀[orange3 slowblink]⠀⠘⣏⣀⢰⣆⠀⠀⠀⠀⠀[/]
            ⠀⠀[orange3 slowblink]⠀⠀⠀⣠⣶⣶⣅⣠⣶[/][red1 rapidblink]⠀⠒⠟⢁⡴⠋⠀⠀⠀⢹⣿⣿⡋⣧⢸⡇⡏⣀⣀[/]⠀[orange3 slowblink]⠀⠙⣿⣉⠙⢤⡄⠀⠀⠀[/]
            ⠀[orange3 slowblink]⠀⣠⣴⣺⢿⣿⣿⡛⠛[/][red1 rapidblink]⠿⠿⣯⣷⡲⣶⣟⣻⡀⠀⣠⣿⣿⣖⣸⣨⣿⠿⠛[/]⠀[orange3 slowblink]⣻⣿⣶⣾⣾⠇⠀⠻⣄⠀⠀[/]
            [orange3 slowblink]⠀⣾⢟⠿⠿⢶⣮⡙⢏⢢⡀[/][red1 rapidblink]⢠⡌⣿⣿⡿⠟⡿⢳⣼⣿⣿⣿⣾⣿⣧⣤⣤[/]⠀[orange3 slowblink]⣤⣿⣿⣭⣿⠁⠀⠀⣀⣈⣧⠀[/]
            [orange3 slowblink]⢺⣥⢿⠾⠿⠿⠿⡿⠚⢋⣠⠯⣿⢉⢉⠻⠾⠛⢿⣿⠻⠿⢛⢋⣤⣯⣭⠽⠶⣾⣻⢿⣻⢿⠶⢛⣻⡿⢽⠄[/]
            ";
    public string BonfireScreen()
    {
        Console.Clear();
        var menuChoices = new SelectionPrompt<string>()
            .AddChoices(
                "Travel",
                "Venture forth",
                "View map",
                "View Character",
                "Level up",
                "Save and exit game");
        BonfireHeader();
        Console.WriteLine();
        Console.WriteLine();

        return AnsiConsole.Prompt(menuChoices);
    }

    private void BonfireHeader()
    {
        var rule = new Rule();
        var locationTitle = new FigletText(Area.AreaName)
        {
            Color = Color.Orange1
        };
        AnsiConsole.Markup(BonfireImage);
        Console.WriteLine();
        AnsiConsole.Write(locationTitle);
        Console.WriteLine();
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

}