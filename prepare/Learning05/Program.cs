using System;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square square = new Square("Red", 5);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 5, 10);
        shapes.Add(rectangle);

        Circle circle = new Circle("Yellow", 5);
        shapes.Add(circle);

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"The {s.GetColor()} shape has an area of {s.GetArea()}.");
        }
    }
}