using System;
using System.Collections.Generic;

// Base class for goals
public abstract class Goal
{
    protected string Name;
    protected int Points;

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    // Abstract method to be overridden by derived classes
    public abstract void RecordProgress();

    public void DisplayStatus()
    {
        Console.WriteLine($"{Name}: {Points} points");
    }
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Console.WriteLine($"Goal completed: {Name}");
        Points += 100; // Example: Earn 100 points for each completion
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        Console.WriteLine($"Progress made on eternal goal: {Name}");
        Points += 50; // Example: Earn 50 points for each recording
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    private int TotalCompletions;
    private int BonusPoints;

    public ChecklistGoal(string name, int points, int totalCompletions, int bonusPoints) : base(name, points)
    {
        TotalCompletions = totalCompletions;
        BonusPoints = bonusPoints;
    }

    public override void RecordProgress()
    {
        Console.WriteLine($"Goal recorded: {Name}");
        Points += 50; // Example: Earn 50 points for each recording
        CheckBonus();
    }

    private void CheckBonus()
    {
        if (Points >= TotalCompletions * Points)
        {
            Console.WriteLine($"Bonus achieved for completing {TotalCompletions} times!");
            Points += BonusPoints;
        }
    }

    public void DisplayStatusWithChecklist()
    {
        Console.WriteLine($"{Name}: {Points} points (Completed {TotalCompletions}/{TotalCompletions} times)");
    }
}

// User class to manage goals and scores
public class User
{
    private string Username;
    private int CurrentScore;
    private List<Goal> Goals;

    public User(string username)
    {
        Username = username;
        CurrentScore = 0;
        Goals = new List<Goal>();
    }

    public void CreateGoal(Goal goal)
    {
        Goals.Add(goal);
        Console.WriteLine($"New goal created: {goal.Name}");
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < Goals.Count)
        {
            Goals[goalIndex].RecordProgress();
            CurrentScore += Goals[goalIndex].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine($"Goals for {Username}:");
        foreach (var goal in Goals)
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                checklistGoal.DisplayStatusWithChecklist();
            }
            else
            {
                goal.DisplayStatus();
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score for {Username}: {CurrentScore} points");
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        User user = new User("JarweeLincoln");

        Goal simpleGoal = new SimpleGoal("Run a Marathon", 0);
        Goal eternalGoal = new EternalGoal("Read Scriptures", 0);
        Goal checklistGoal = new ChecklistGoal("Attend Temple", 0, 10, 500);

        user.CreateGoal(simpleGoal);
        user.CreateGoal(eternalGoal);
        user.CreateGoal(checklistGoal);

        user.RecordEvent(0); // Record progress for running a marathon
        user.RecordEvent(1); // Record progress for reading scriptures
        user.RecordEvent(2); // Record progress for attending the temple

        user.DisplayGoals();
        user.DisplayScore();
    }
}
