using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("green", 1.75));
        shapes.Add(new Rectangle("red", 2.1, 5));
        shapes.Add(new Circle("blue", 2));

        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
        }
    }
}