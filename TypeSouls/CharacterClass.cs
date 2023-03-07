﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls;
public class CharacterClass
{
    public String ClassName { get; set; }
    public int Strength { get; set; }
    public int Intellect { get; set; }
    public int Endurance { get; set; }
    public int Faith { get; set; }

    public CharacterClass(string name, int str, int intellect, int end, int fth)
    {
        ClassName = name;
        Strength = str;
        Intellect = intellect;
        Endurance = end;
        Faith = fth;
    }
}

