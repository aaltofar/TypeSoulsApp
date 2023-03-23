using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Entities;
internal class Invader : IOpponent
{
    public string Name { get; set; }
    public int Health { get; set; }
}

