// Shape.cs

public class Shape
{
    private string color;

    // Constructor that accepts the color and sets it
    public Shape(string color)
    {
        this.color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return color;
    }

    // Setter for color (optional, depends on your requirements)
    public void SetColor(string color)
    {
        this.color = color;
    }

    // Virtual method for calculating area
    public virtual double GetArea()
    {
        // Default implementation returns 0.0 (can be overridden by derived classes)
        return 0.0;
    }
}
