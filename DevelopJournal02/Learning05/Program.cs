// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Test the Square class
        Square square = new Square("Blue", 5.0);
        Console.WriteLine($"Square Color: {square.GetColor()}");
        Console.WriteLine($"Square Area: {square.GetArea()}");
        Console.WriteLine($"Square Side: {square.GetSide()}");
        Console.WriteLine();

        // Test the Rectangle class
        Rectangle rectangle = new Rectangle("Red", 4.0, 6.0);
        Console.WriteLine($"Rectangle Color: {rectangle.GetColor()}");
        Console.WriteLine($"Rectangle Area: {rectangle.GetArea()}");
        Console.WriteLine($"Rectangle Length: {rectangle.GetLength()}, Width: {rectangle.GetWidth()}");
        Console.WriteLine();

        // Test the Circle class
        Circle circle = new Circle("Green", 3.0);
        Console.WriteLine($"Circle Color: {circle.GetColor()}");
        Console.WriteLine($"Circle Area: {circle.GetArea()}");
        Console.WriteLine($"Circle Radius: {circle.GetRadius()}");
    }
}
