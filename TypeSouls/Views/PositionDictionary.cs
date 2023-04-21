using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Views;
internal class PositionDictionary
{
    private readonly Dictionary<string, int> _positionDictionary = new();

    public PositionDictionary()
    {
        _positionDictionary.Add("YTop", Console.WindowHeight / 8);
        _positionDictionary.Add("YMid", Console.WindowHeight / 2);
        _positionDictionary.Add("YBot", Console.WindowHeight / 4 * 3);
        _positionDictionary.Add("XLeft", Console.WindowWidth / 8);
        _positionDictionary.Add("XMid", Console.WindowWidth / 2);
        _positionDictionary.Add("XRight", Console.WindowWidth / 4 * 3);
    }

    public int GetPosition(string position)
    {
        return _positionDictionary[position];
    }
}

