using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool Completed { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        Completed = false;
    }

    public abstract int Complete();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int Complete()
    {
        Completed = true;
        return Points;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int Complete()
    {
        return Points;
    }
}

public class ChecklistGoal : Goal
{
    public int Times { get; set; }
    public int Count { get; set; }

    public ChecklistGoal(string name, int points, int times) : base(name, points)
    {
        Times = times;
        Count = 0;
    }

    public override int Complete()
    {
        Count++;
        if (Count >= Times)
        {
            Completed = true;
            return Points;
        }
        return Points;
    }
}

public class User
{
    public int Score { get; set; }
    public List<Goal> Goals { get; set; }

    public User()
    {
        Score = 0;
        Goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void CompleteGoal(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.Name == goalName)
            {
                Score += goal.Complete();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User();
        Console.WriteLine("Welcome to the Goal Tracker!");
        while (true)
        {
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. Complete a goal");
            Console.WriteLine("3. View score");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal points: ");
                    int points = Convert.ToInt32(Console.ReadLine());
                    Goal goal = new SimpleGoal(name, points);
                    user.AddGoal(goal);
                    break;
                case 2:
                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();
                    user.CompleteGoal(goalName);
                    break;
                case 3:
                    Console.WriteLine($"Your score is: {user.Score}");
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
