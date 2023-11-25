using System;
using System.Collections.Generic;

// Base Shape class
public class Shape
{
    private string color;

    public Shape(string color)
    {
        this.color = color;
    }

    public string GetColor()
    {
        return color;
    }

    // Virtual method for calculating area
    public virtual double GetArea()
    {
        return 0.0;
    }
}

// Square class
public class Square : Shape
{
    private double side;

    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    // Override GetArea for squares
    public override double GetArea()
    {
        return side * side;
    }
}

// Rectangle class
public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        this.length = length;
        this.width = width;
    }

    // Override GetArea for rectangles
    public override double GetArea()
    {
        return length * width;
    }
}

// Circle class
public class Circle : Shape
{
    private double radius;

    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    // Override GetArea for circles
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

class Program
{
    static void Main()
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add a square, rectangle, and circle to the list
        shapes.Add(new Square("Red", 4.0));
        shapes.Add(new Rectangle("Blue", 5.0, 3.0));
        shapes.Add(new Circle("Green", 2.5));

        // Iterate through the list of shapes
        foreach (Shape shape in shapes)
        {
            // Display color and area for each shape
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea():F2}\n");
        }
    }
}
