using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Entities;
public class NonPlayerCharacter
{
    public string Name { get; set; }
    public List<string> Dialogue { get; set; }

    public NonPlayerCharacter(string name)
    {
        Name = name;
    }

    public NonPlayerCharacter(string name, List<string> dialogue)
    {
        Name = name;
        Dialogue = dialogue;
    }

    public NonPlayerCharacter()
    {

    }

}

