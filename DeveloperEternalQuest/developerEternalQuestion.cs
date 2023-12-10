using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Create an instance of the EternalQuestManager
        EternalQuestManager questManager = new EternalQuestManager();

        // Load saved goals and scores
        questManager.Load();

        // Main menu
        while (true)
        {
            Console.WriteLine("Eternal Quest - Goal Tracking Program");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save and Exit");

            int choice = GetIntInput("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    questManager.DisplayGoals();
                    break;
                case 2:
                    questManager.AddGoal();
                    break;
                case 3:
                    questManager.RecordEvent();
                    break;
                case 4:
                    questManager.DisplayScore();
                    break;
                case 5:
                    // Save goals and scores before exiting
                    questManager.Save();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Helper method to get integer input from the user
    static int GetIntInput(string prompt)
    {
        int input;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

// Base class for goals
class Goal
{
    public string Name { get; set; }
    protected int Value { get; set; }

    public virtual void DisplayProgress()
    {
        // Display goal progress
    }

    public virtual void RecordEvent()
    {
        // Record goal completion event
    }
}

// Derived class for simple goals
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"{Name} completed! You gained {Value} points.");
    }
}

// Derived class for eternal goals
class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"{Name} in progress! You gained {Value} points.");
    }
}

// Derived class for checklist goals
class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;

    public ChecklistGoal(string name, int value, int targetCount)
    {
        Name = name;
        Value = value;
        this.targetCount = targetCount;
    }

    public override void RecordEvent()
    {
        completedCount++;
        Console.WriteLine($"{Name} completed ({completedCount}/{targetCount})! You gained {Value} points.");

        // Check if the goal is completed
        if (completedCount == targetCount)
        {
            Console.WriteLine($"Bonus! Goal {Name} completed. You gained an extra {Value * 2} points.");
            completedCount = 0; // Reset the count for the next round
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"Completed {completedCount}/{targetCount} times.");
    }
}

// Manager class to handle goals and scores
class EternalQuestManager
{
    private List<Goal> goals;
    private int totalScore;

    public EternalQuestManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice = Program.GetIntInput("Enter your choice: ");

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the point value: ");
        int value = Program.GetIntInput("");

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal(name, value));
                break;
            case 2:
                goals.Add(new EternalGoal(name, value));
                break;
            case 3:
                Console.Write("Enter the target count for the checklist goal: ");
                int targetCount = Program.GetIntInput("");
                goals.Add(new ChecklistGoal(name, value, targetCount));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select the goal to record an event for:");
        DisplayGoals();

        int choice = Program.GetIntInput("Enter the goal number: ");

        if (choice >= 1 && choice <= goals.Count)
        {
            goals[choice - 1].RecordEvent();
            totalScore += goals[choice - 1].Value;
        }
        else
        {
            Console.WriteLine("Invalid goal number. Event not recorded.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. {goals[i].Name} - ");
            goals[i].DisplayProgress();
        }

        Console.WriteLine();
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Value}");
            }
        }

        using (StreamWriter writer = new StreamWriter("score.txt"))
        {
            writer.WriteLine(totalScore);
        }
    }

    public void Load()
    {
        try
        {
            // Load goals from file
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string type = parts[0];
                        string name = parts[1];
                        int value = int.Parse(parts[2]);

                        switch (type)
                        {
                            case nameof(SimpleGoal):
                                goals.Add(new SimpleGoal(name, value));
                                break;
                            case nameof(EternalGoal):
                                goals.Add(new EternalGoal(name, value));
                                break;
                            case nameof(ChecklistGoal):
                                Console.Write("Enter the target count for the checklist goal: ");
                                int targetCount = Program.GetIntInput("");
                                goals.Add(new ChecklistGoal(name, value, targetCount));
                                break;
                            default:
                                Console.WriteLine($"Unknown goal type: {type}");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid line in goals file: {line}");
                    }
                }
            }

            // Load
