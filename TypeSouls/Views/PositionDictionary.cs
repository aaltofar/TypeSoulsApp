namespace TypeSouls.Views;
public static class PositionDictionary
{
    private static readonly Dictionary<string, (int, int)> _positionDictionary = new()
    {
        {"MidMid", (Console.WindowWidth / 2, Console.WindowHeight / 2)},
        {"MidTop", (Console.WindowWidth / 2, Console.WindowHeight / 8)},
        {"MidBot", (Console.WindowWidth / 2, Console.WindowHeight / 4 * 3)},
        {"LeftMid", (Console.WindowWidth / 8, Console.WindowHeight / 2)},
        {"LeftTop", (Console.WindowWidth / 8, Console.WindowHeight / 8)},
        {"LeftBot", (Console.WindowWidth / 8, Console.WindowHeight / 4 * 3)},
        {"RightMid", (Console.WindowWidth / 4 * 3 + 20, Console.WindowHeight / 2)},
        {"RightTop", (Console.WindowWidth / 4 * 3 + 20, Console.WindowHeight / 8)},
        {"RightBot", (Console.WindowWidth / 4 * 3 + 20, Console.WindowHeight / 4 * 3)}
    };

    public static (int, int) GetPosition(string position)
    {
        return _positionDictionary[position];
    }
}

