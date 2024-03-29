﻿
namespace TypeSouls.Entities;
public class Enemy : IOpponent, IEntity
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public bool IsBoss { get; set; }
    private List<string> AllNamesList { get; set; }
    private Random R { get; } = new Random();
    public bool IsAlive { get; set; }

    public Enemy()
    {
        AllNamesList = File.ReadLines(Path.Combine(GameService.GetProjectFolder(), "Data", "EnemyList.txt")).ToList();
        Name = AllNamesList[R.Next(AllNamesList.Count)];
        CurrentHealth = 100;
        IsAlive = true;
    }

    public void TakeDamage(int damage)
    {
        if (CurrentHealth - damage < 0)
        {
            CurrentHealth = 0;
            IsAlive = false;
            return;
        }

        CurrentHealth -= damage;
    }

    public string MakeHealthBar()
    {
        int missingHealth = (100 - CurrentHealth) / 5;

        string bar = new('█', CurrentHealth is > 0 and < 5 ? CurrentHealth / 5 + 1 : CurrentHealth / 5);
        string missingBar = new('█', missingHealth);

        return "[maroon]" + bar + "[/]" + "[silver]" + missingBar + "[/]";
    }

}

