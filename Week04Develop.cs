using System;
using System.Threading;

// Base class for all activities
class Activity
{
    private int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    public void Start()
    {
        DisplayStartingMessage();
        Thread.Sleep(3000); // Pause for several seconds

        PerformActivity();

        DisplayEndingMessage();
        Thread.Sleep(3000); // Pause for several seconds
    }

    protected virtual void PerformActivity()
    {
        // Base implementation does nothing
    }

    private void DisplayStartingMessage()
    {
        Console.WriteLine("********** Starting Activity **********");
        Console.WriteLine($"Activity Type: {GetType().Name}");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Prepare to begin...");
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine("********** Activity Completed **********");
        Console.WriteLine($"You've done a good job!");
        Console.WriteLine($"Activity Type: {GetType().Name}");
        Console.WriteLine($"Duration: {duration} seconds");
    }
}

// Derived class for Breathing activity
class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");

        for (int i = 0; i < GetDuration(); i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for one second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for one second
        }
    }
}

// Derived class for Reflection activity
class ReflectionActivity : Activity
{
    private static readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] reflectionQuestions = {
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

    public ReflectionActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");

        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);

        foreach (string question in reflectionQuestions)
        {
            Console.WriteLine(question);
            Thread.Sleep(2000); // Pause for two seconds
            ShowSpinner();
        }
    }

    private void ShowSpinner()
    {
        // Display a spinner animation
        Console.Write("/ ");
        Thread.Sleep(500);
        Console.Write("- ");
        Thread.Sleep(500);
        Console.Write("\\ ");
        Thread.Sleep(500);
        Console.Write("| ");
        Thread.Sleep(500);
    }
}

// Derived class for Listing activity
class ListingActivity : Activity
{
    private static readonly string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    protected override void PerformActivity()
    {
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string prompt = listingPrompts[new Random().Next(listingPrompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("Get ready to start listing...");
        Thread.Sleep(3000); // Pause for three seconds

        Console.WriteLine("Go!");
        for (int i = 1; i <= GetDuration(); i++)
        {
            Console.WriteLine($"Item {i}");
            Thread.Sleep(1000); // Pause for one second
        }

        Console.WriteLine($"Number of items entered: {GetDuration()}");
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        Activity breathingActivity = new BreathingActivity(5);
        breathingActivity.Start();

        Activity reflectionActivity = new ReflectionActivity(10);
        reflectionActivity.Start();

        Activity listingActivity = new ListingActivity(8);
        listingActivity.Start();
        
    }
}
