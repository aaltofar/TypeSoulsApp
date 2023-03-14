using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
internal class BonfireMenu
{
    static public void BonfireScreen()
    {
        var bonfireImage = @"
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

        var choice2 = new SelectionPrompt<string>()
            .AddChoices(
                "Travel",
                "View Character",
                "Level up",
                "View map",
                "Save game",
                "Save and exit game");
        var rule = new Rule();
        var locationTitle = new FigletText("Anor Londo");
        rule.LeftJustified();
        AnsiConsole.Markup(bonfireImage);
        Console.WriteLine();
        AnsiConsole.Write(locationTitle);
        Console.WriteLine();
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
        AnsiConsole.Prompt(choice2);
    }
}