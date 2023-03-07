using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls;
public class Game
{
    public List<CharacterClass>? AllClasses { get; set; }

    public Game()
    {
        AllClasses?.Add(new CharacterClass("Warrior", 10, 5, 5, 5));
        AllClasses?.Add(new CharacterClass("Knight", 5, 5, 10, 5));
        AllClasses?.Add(new CharacterClass("Cleric", 5, 5, 5, 10));
        AllClasses?.Add(new CharacterClass("Sorcerer", 5, 10, 5, 5));
        AllClasses?.Add(new CharacterClass("Deprived", 1, 1, 1, 1));
    }

}

