using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
internal class ConsoleLayoutWriter
{
    public (int, int) MidMid { get; set; }
    public (int, int) MidTop { get; set; }
    public (int, int) MidBot { get; set; }

    public (int, int) LeftMid { get; set; }
    public (int, int) LeftTop { get; set; }
    public (int, int) LeftBot { get; set; }

    public (int, int) RightMid { get; set; }
    public (int, int) RightTop { get; set; }
    public (int, int) RightBot { get; set; }

    public ConsoleLayoutWriter()
    {
        MidMid = (Console.WindowWidth / 2, Console.WindowHeight / 2);
        MidTop = (Console.WindowWidth / 2, Console.WindowHeight / 8);
        MidBot = (Console.WindowWidth / 2, Console.WindowHeight / 4 * 3);

        LeftMid = (Console.WindowWidth / 8, Console.WindowHeight / 2);
        LeftTop = (Console.WindowWidth / 8, Console.WindowHeight / 8);
        LeftBot = (Console.WindowWidth / 8, Console.WindowHeight / 4 * 3);

        RightMid = (Console.WindowWidth / 4 * 3, Console.WindowHeight / 2);
        RightTop = (Console.WindowWidth / 4 * 3, Console.WindowHeight / 8);
        RightBot = (Console.WindowWidth / 4 * 3, Console.WindowHeight / 4 * 3);
    }

    public void Writer(string text, (int, int) position)
    {
        Console.SetCursorPosition(position.Item1, position.Item2);
        Console.Write(text);
    }
}

