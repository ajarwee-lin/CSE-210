using System;

class Program
{
    static void Main()
    {
        Console.Write("A. Lincoln: ");
        string firstName = Console.ReadLine();

        Console.Write("Jarwee: ");
        string lastName = Console.ReadLine();

        // Display the formatted name
        Console.WriteLine($"Your name is {lastName}, {firstName}, {lastName}");
    }
}
