using System;

class Program
{
    static void Main(string[] args)
    {
        /**************/
        /* Unit Tests */
        /**************/
        // Console.Clear();
        // Square square= new Square("red", 2);
        // Console.WriteLine($"Square area: {square.GetArea()} <-- 4 expected");
        // Console.WriteLine($"Square Color: {square.GetColor()} <-- 'red' expected\n");
        
        // Rectangle rectangle= new Rectangle("blue", 2, 4);
        // Console.WriteLine($"Rectangle area: {rectangle.GetArea()} <-- 8 expected");
        // Console.WriteLine($"Rectangle color: {rectangle.GetColor()} <-- 'blue' expected\n");

        // Circle circle= new Circle("orange", 2);
        // Console.WriteLine($"Circle area: {circle.GetArea()} <-- approx. 12.56637 expected");
        // Console.WriteLine($"Circle Color: {circle.GetColor()} <-- 'orange' expected\n");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 2));
        shapes.Add(new Rectangle("blue", 2, 4));
        shapes.Add(new Circle("orange", 2));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            
        }
    }
}