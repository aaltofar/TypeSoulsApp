using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
public static class BonfireMenu
{
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
    public static string BonfireScreen()
    {
        var choice2 = new SelectionPrompt<string>()
            .AddChoices(
                "Travel",
                "View Character",
                "Level up",
                "View map",
                "Save and exit game");
        BonfireHeader();
        Console.WriteLine();
        Console.WriteLine();

        return AnsiConsole.Prompt(choice2);
    }

    static void BonfireHeader()
    {
        var rule = new Rule();
        var font = FigletFont.Load("starwars.flf");
        var locationTitle = new FigletText(font, "Anor Londo")
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