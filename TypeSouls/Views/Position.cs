namespace TypeSouls.Views;
public static class Position
{
    public static (int, int) MidMid = (Console.WindowWidth / 2, Console.WindowHeight / 2);
    public static (int, int) MidTop = (Console.WindowWidth / 2, Console.WindowHeight / 8);
    public static (int, int) MidBot = (Console.WindowWidth / 2, Console.WindowHeight / 4 * 3);

    public static (int, int) LeftMid = (Console.WindowWidth / 8, Console.WindowHeight / 2);
    public static (int, int) LeftTop = (Console.WindowWidth / 8, Console.WindowHeight / 8);
    public static (int, int) LeftBot = (Console.WindowWidth / 8, Console.WindowHeight / 4 * 3);

    public static (int, int) RightMid = (Console.WindowWidth / 4 * 3 + 20, Console.WindowHeight / 2);
    public static (int, int) RightTop = (Console.WindowWidth / 4 * 3 + 20, Console.WindowHeight / 8);
    public static (int, int) RightBot = (Console.WindowWidth / 4 * 3 + 20, Console.WindowHeight / 4 * 3);
}

