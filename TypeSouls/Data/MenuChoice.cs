using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSouls.Data;
public class MenuChoice
{
    public string ChoiceName { get; set; }
    public string ChoiceDescription { get; set; }

    public MenuChoice(string choiceName, string choiceDescription)
    {
        ChoiceName = choiceName;
        ChoiceDescription = choiceDescription;
    }

    public MenuChoice(string choiceName)
    {
        ChoiceName = choiceName;
        ChoiceDescription = "";
    }
}

