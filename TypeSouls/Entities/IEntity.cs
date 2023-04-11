using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Entities;
public interface IEntity
{
    public int CurrentHealth { get; set; }

    public string MakeHealthBar();

}

