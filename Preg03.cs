using System;

class Program
{
    static void Main()
    {
        // Step 1: Ask the user for the magic number (You can replace this with a random number generation)
        Console.Write("Enter the magic number: ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guess;
        bool correctGuess = false;

        // Step 4: Add a loop to keep playing until the guess is correct
        while (!correctGuess)
        {
            // Step 2: Ask the user for a guess
            Console.Write("Guess the magic number: ");
            guess = int.Parse(Console.ReadLine());

            // Step 3: Use an if statement to provide feedback
            if (guess < magicNumber)
            {
                Console.WriteLine("Guess higher!");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Guess lower!");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed the magic number.");
                correctGuess = true; // Exit the loop when the guess is correct
            }
        }
    }
}
