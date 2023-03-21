﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSouls.Entities;

namespace TypeSouls;
public class Boss : IOpponent
{
    public string Name { get; set; }
    public int Health { get; set; }
    public bool IsAlive { get; set; }
}

