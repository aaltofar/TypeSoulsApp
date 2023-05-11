using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TypeSouls.Data;

namespace TypeSouls.Views;
public static class ConsoleService
{
    private static int _currentSelection;

    private static readonly int XLeftPosition = 2;
    private static readonly int XMidPosition = Console.WindowWidth / 2;
    private static readonly int XRightPosition = Console.WindowWidth / 4 * 3 + 20;

    private static readonly int YTopPosition = Console.WindowHeight / 8;
    private static readonly int YMidPosition = Console.WindowHeight / 2 - Console.WindowHeight / 9;
    private static readonly int YBotPosition = Console.WindowHeight / 4 * 3;

    private const int DefaultDescriptionVerticalPadding = 2;

    public static void MakeHeader(string? figTxt, [Optional] string lineTxt, Color figColor = default, string fontName = "standard")
    {
        Console.Clear();

        var font = FigletFont.Load($"{fontName}.flf");

        AnsiConsole.Write(new FigletText(font, figTxt).Centered().Color(figColor));
        var divider = lineTxt == string.Empty ? new Rule() : new Rule(lineTxt) { Justification = Justify.Center };
        AnsiConsole.Write(divider);
    }

    public static void PrintLayout(Layout modules)
    {
        modules.GetModules();
        foreach (var m in modules.GetModules().Where(module => module != null))
        {
            for (int i = 0; i < m.Count; i++)
            {
                if (m == modules.LeftTop)
                {
                    SetWritePosition("leftTop", i, false, stringLength: m[i].Length);
                    AnsiConsole.Markup(m[i]);
                }
                if (m == modules.LeftMid)
                {
                    SetWritePosition("leftMid", i, false, stringLength: m[i].Length);
                    Console.Write(m[i]);
                }
                if (m == modules.LeftBot)
                {
                    SetWritePosition("leftBot", i, false, stringLength: m[i].Length);
                    Console.Write(m[i]);
                }
                if (m == modules.MidTop)
                {
                    SetWritePosition("midTop", i, false, stringLength: m[i].Length);
                    Console.Write(m[i]);
                }
                if (m == modules.MidMid)
                {
                    SetWritePosition("midMid", i, false, stringLength: m[i].Length);
                    AnsiConsole.Markup(m[i]);
                }
                if (m == modules.MidBot)
                {
                    SetWritePosition("midBot", i, false, stringLength: m[i].Length);
                    Console.Write(m[i]);
                }
                if (m == modules.RightTop)
                {
                    SetWritePosition("rightTop", i, false, stringLength: m[i].Length);
                    AnsiConsole.Markup(m[i]);
                }
                if (m == modules.RightMid)
                {
                    SetWritePosition("rightMid", i, false, stringLength: m[i].Length);
                    Console.Write(m[i]);
                }
                if (m == modules.RightBot)
                {
                    SetWritePosition("rightBot", i, false, stringLength: m[i].Length);
                    Console.Write(m[i]);
                }
            }
        }
        Console.CursorVisible = false;
    }

    public static (string, ConsoleKey) MakeArrowMenu(List<MenuChoice> choices, string position)
    {
        Console.CursorVisible = false;

        for (var i = 0; i < choices.Count; i++)
        {

            SetWritePosition(position, i, false, choices.Count, choices[i].ChoiceName.Length);

            if (i == _currentSelection)
                AnsiConsole.Markup($"[steelblue3]{choices[i].ChoiceName}[/]");

            else
                Console.Write(choices[i].ChoiceName);

            SetWritePosition(position, i, true, choices.Count, choices[i].ChoiceDescription.Length);

            if (i == _currentSelection)
            {
                for (int j = 0; j < choices[i].ChoiceDescription.Length; j++)
                    AnsiConsole.Markup("[dim grey]_[/]");

                SetWritePosition(position, i, true, choices.Count + 1, choices[i].ChoiceDescription.Length);
                AnsiConsole.Markup($"[dim orange3]{choices[i].ChoiceDescription}[/]");
            }
        }

        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                {
                    if (_currentSelection > 0)
                        _currentSelection--;
                    break;
                }
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                {
                    if (_currentSelection < choices.Count - 1)
                        _currentSelection++;

                    break;
                }
        }

        return choices.Count == 0 ? ("", key) : (choices[_currentSelection].ChoiceName, key);
    }

    private static void SetWritePosition(string position, [Optional] int i, [Optional] bool isDescription, [Optional] int yOffset, [Optional] int stringLength)
    {
        int verticalOffset = yOffset + DefaultDescriptionVerticalPadding;

        switch (position)
        {
            case "leftTop": Console.SetCursorPosition(XLeftPosition, isDescription ? YTopPosition + verticalOffset : YTopPosition + i); break;
            case "leftMid": Console.SetCursorPosition(XLeftPosition, isDescription ? YMidPosition + verticalOffset : YMidPosition + i); break;
            case "leftBot": Console.SetCursorPosition(XLeftPosition, isDescription ? YBotPosition + verticalOffset : YBotPosition + i); break;

            case "midTop": Console.SetCursorPosition(XMidPosition - stringLength / 2, isDescription ? YTopPosition + verticalOffset : YTopPosition + i); break;
            case "midMid": Console.SetCursorPosition(XMidPosition - stringLength / 2, isDescription ? YMidPosition + verticalOffset : YMidPosition + i); break;
            case "midBot": Console.SetCursorPosition(XMidPosition - stringLength / 2, isDescription ? YBotPosition + verticalOffset : YBotPosition + i); break;

            case "rightTop": Console.SetCursorPosition(XRightPosition, isDescription ? YTopPosition + verticalOffset : YTopPosition + i); break;
            case "rightMid": Console.SetCursorPosition(XRightPosition, isDescription ? YMidPosition + verticalOffset : YMidPosition + i); break;
            case "rightBot": Console.SetCursorPosition(XRightPosition, isDescription ? YBotPosition + verticalOffset : YBotPosition + i); break;
        }
    }

    public static void MakeFooter()
    {
        var divider = new Rule();
        Console.SetCursorPosition(XLeftPosition, YBotPosition);
        AnsiConsole.Write(divider);
        Console.ReadLine();
    }

    public static void DrawScreen()
    {

    }

    public static void DialoguePrompter(NonPlayerCharacter npc)
    {
        var dialogueLayout = new Layout();

        for (int i = 0; i < npc.Dialogue.Count; i++)
        {
            Console.Clear();
            dialogueLayout.MidMid = new List<string>()
            {
               "[dim orange3]" + npc.Name + "[/]" + ":",
                "",
                npc.Dialogue[i]
            };

            PrintLayout(dialogueLayout);
            Console.ReadLine();
        }
    }

    public static void BossDialoguePrompter(Boss boss)
    {
        var dialogueLayout = new Layout();

        for (int i = 0; i < boss.DialogueList.Count; i++)
        {
            Console.Clear();
            dialogueLayout.MidMid = new List<string>()
            {
                boss.DialogueList[i],
                "",
                $"{i+1}/{boss.DialogueList.Count}"
            };
            PrintLayout(dialogueLayout);
            Console.ReadLine();
        }
    }

    public static void StringArraySplitter(Area area)
    {
        var areaLayout = new Layout();

        for (int i = 0; i < area.AreaDescription.Count; i++)
        {
            Console.Clear();
            areaLayout.MidMid = new List<string>()
            {
                area.AreaDescription[i],
                "",
                $"{i+1}/{area.AreaDescription.Count}"
            };
            PrintLayout(areaLayout);
            Console.ReadLine();
        }
    }

    public static string TalkToNpcChoice()
    {
        _currentSelection = 0;
        var _key = ConsoleKey.NoName;
        var menuChoice = string.Empty;

        const string spotPerson = "As you look around the area you see another person";


        while (_key != ConsoleKey.Enter)
        {
            Console.Clear();
            SetWritePosition("midTop", stringLength: spotPerson.Length);
            Console.WriteLine(spotPerson);

            var menu = MakeArrowMenu(new List<MenuChoice>
        {
            new MenuChoice("Talk", "Approach the person, have a conversation"),
            new MenuChoice("Leave", "Leave the person alone, go your own way"),
        }, "midMid");

            _key = menu.Item2;
            menuChoice = menu.Item1;
        }


        return menuChoice;
    }
}