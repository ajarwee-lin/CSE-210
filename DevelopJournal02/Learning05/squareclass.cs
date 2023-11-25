// Square.cs
public class Square : Shape
{
    private double side;

    // Constructor that accepts color and side, and calls the base constructor
    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    // Getter for side (optional, depends on your requirements)
    public double GetSide()
    {
        return side;
    }

    // Setter for side (optional, depends on your requirements)
    public void SetSide(double side)
    {
        this.side = side;
    }

    // Override GetArea method to calculate area for a square
    public override double GetArea()
    {
        // Area of a square is side squared
        return side * side;
    }
}
