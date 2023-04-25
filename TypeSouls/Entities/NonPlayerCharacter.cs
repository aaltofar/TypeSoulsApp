using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Entities;
internal class NonPlayerCharacter
{
    public string Name { get; set; }
    private List<string>? Dialogue { get; set; }

    public NonPlayerCharacter(string name)
    {
        Name = name;
        Dialogue = FillDialogueList();
    }

    public NonPlayerCharacter()
    {
        Dialogue = FillDialogueList();
        Name = "NoName";
    }

    private List<string> FillDialogueList()
    {
        return new List<string>();
    }

}

