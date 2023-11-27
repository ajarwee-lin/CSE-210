using System;
using System.Collections.Generic;
using System.Threading;

// Base class for mindfulness activities
public abstract class MindfulnessActivity
{
    protected string activityName;
    protected string activityDescription;

    public MindfulnessActivity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    public void PerformActivity(int duration)
    {
        DisplayStartMessage(duration);
        ExecuteActivity(duration);
        DisplayEndMessage(duration);
    }

    protected void DisplayStartMessage(int duration)
    {
        Console.WriteLine($"Starting {activityName} - {activityDescription}");
        Console.WriteLine($"Duration: {duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected abstract void ExecuteActivity(int duration);

    protected void DisplayEndMessage(int duration)
    {
        Console.WriteLine($"Congratulations! You've completed {activityName}");
        Console.WriteLine($"Time spent: {duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine("Well done!");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.Clear(); // Clear the console for the next activity
    }
}

// Breathing activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "Deep breathing for relaxation") { }

    protected override void ExecuteActivity(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }
}

// Reflection activity
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "Reflect on times of strength and resilience") { }

    protected override void ExecuteActivity(int duration)
    {
        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");
            Thread.Sleep(3000); // Pause for 3 seconds

            foreach (var question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000); // Pause for 2 seconds
            }
        }
    }
}

// Listing activity
public class ListingActivity : MindfulnessActivity
{
    private List<string> listPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "List positive things in your life") { }

    protected override void ExecuteActivity(int duration)
    {
        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string listPrompt = listPrompts[random.Next(listPrompts.Count)];
            Console.WriteLine($"Prompt: {listPrompt}");
            Thread.Sleep(5000); // Pause for 5 seconds

            Console.WriteLine("Start listing items...");
            Thread.Sleep(1000); // Pause for 1 second

            // Simulate user listing items (actual implementation may involve user input)
            int itemsCount = random.Next(5, 15);
            for (int j = 1; j <= itemsCount; j++)
            {
                Console.WriteLine($"Item {j}");
                Thread.Sleep(1000); // Pause for 1 second
            }

            Console.WriteLine($"Number of items listed: {itemsCount}");
        }
    }
}

// Main program
class Program
{
    static void Main()
    {
        Console.WriteLine("Mindfulness Program");

        // Initialize activities
        MindfulnessActivity breathingActivity = new BreathingActivity();
        MindfulnessActivity reflectionActivity = new ReflectionActivity();
        MindfulnessActivity listingActivity = new ListingActivity();

        // Perform activities
        breathingActivity.PerformActivity(5); // Example duration: 5 seconds
        reflectionActivity.PerformActivity(4); // Example duration: 4 seconds
        listingActivity.PerformActivity(6);    // Example duration: 6 seconds

        Console.WriteLine("Program completed.");
    }
}
