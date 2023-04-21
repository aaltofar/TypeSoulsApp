using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TypeSouls.Views;
public static class ConsoleService
{
    private static int _currentSelection;

    private static readonly int XLeftPosition = 2;
    private static readonly int XMidPosition = Console.WindowWidth / 2;
    private static readonly int XRightPosition = Console.WindowWidth / 4 * 3;

    private static readonly int YTopPosition = Console.WindowHeight / 8;
    private static readonly int YMidPosition = Console.WindowHeight / 2 - Console.WindowHeight / 9;
    private static readonly int YBotPosition = Console.WindowHeight / 4 * 3;

    private const int DefaultDescriptionVerticalPadding = 2;

    public static void MakeHeader(string? figTxt, [Optional] string lineTxt, Color figColor = default, string fontName = "standard")
    {
        Console.Clear();

        var font = FigletFont.Load($"{fontName}.flf");

        AnsiConsole.Write(new FigletText(font, figTxt).Centered().Color(figColor));
        var divider = new Rule(lineTxt) { Justification = Justify.Center };
        AnsiConsole.Write(divider);
    }

    public static Layout testLayout()
    {
        return new Layout()
        {
            LeftTop = new List<string>() { "heilo lefttop" },
            MidMid = new List<string>() { "testeteste midmid" },
            RightBot = new List<string>() { "testeteste rightbot" }
        };
    }

    public static void PrintLayout(Layout modules)
    {
        modules.GetModules();
        foreach (var module in modules.GetModules().Where(module => module != null))
        {
            for (int i = 0; i < module.Count; i++)
            {
                if (module == modules.LeftTop)
                {
                    SetWritePosition("leftTop", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.LeftMid)
                {
                    SetWritePosition("leftMid", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.LeftBot)
                {
                    SetWritePosition("leftBot", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.MidTop)
                {
                    SetWritePosition("midTop", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.MidMid)
                {
                    SetWritePosition("midMid", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.MidBot)
                {
                    SetWritePosition("midBot", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.RightTop)
                {
                    SetWritePosition("rightTop", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.RightMid)
                {
                    SetWritePosition("rightMid", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
                if (module == modules.RightBot)
                {
                    SetWritePosition("rightBot", i, false, stringLength: module[i].Length);
                    Console.Write(module[i]);
                }
            }
        }

        Console.ReadLine();
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
        return (choices[_currentSelection].ChoiceName, key);
    }

    public static void TestLayoutThing()
    {
        string[] tester = new[]
        {
            "Teststring nummer 1",
            "Teststring nummer 2",
            "Teststring nummer 3",
            "Teststring nummer 4",
            "Teststring nummer 5",
            "Teststring nummer 6",
            "Teststring nummer 7",
            "Teststring nummer 8",
            "Teststring nummer 9",
        };

        SetWritePosition("leftTop");
        Console.Write(tester[0]);

        SetWritePosition("leftMid");
        Console.Write(tester[1]);

        SetWritePosition("leftBot");
        Console.Write(tester[2]);

        SetWritePosition("midTop", stringLength: tester[3].Length);
        Console.Write(tester[3]);

        SetWritePosition(position: "midMid", stringLength: tester[4].Length);
        Console.Write(tester[4]);

        SetWritePosition("midBot", stringLength: tester[5].Length);
        Console.Write(tester[5]);

        SetWritePosition("rightTop");
        Console.Write(tester[6]);

        SetWritePosition("rightMid");
        Console.Write(tester[7]);

        SetWritePosition("rightBot");
        Console.Write(tester[8]);
        Console.ReadLine();
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

}