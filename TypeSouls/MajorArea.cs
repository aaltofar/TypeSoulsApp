using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls;
internal class MajorArea
{
    public string AreaName { get; set; }
    public List<Location> Locations { get; set; }

    public MajorArea(string name)
    {
        AreaName = name;
    }
}

