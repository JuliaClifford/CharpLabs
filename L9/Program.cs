using System;

namespace L9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Square square = new Square("The Square", 45.14);
            Circle circle = new Circle("The Circle", 112.30, "Red");
            Triangle triangle = new Triangle("The Triangle");

            Console.WriteLine($"Square Perimeter: {square.CalculatePerimeter()} cm");
            Console.WriteLine($"Square Square: {square.CalculateSquare()} cm^2");

            Console.WriteLine($"Circle Perimeter: {circle.CalculatePerimeter()} cm");
            Console.WriteLine($"Circle Square: {circle.CalculateSquare()} cm^2");
            
            Console.WriteLine($"Triangle Perimeter: {triangle.CalculatePerimeter()} cm");
            Console.WriteLine($"Triangle Square: {triangle.CalculateSquare()} cm^2");
            
            Picture picture = new Picture();
            
            picture.AddShape(square);
            picture.AddShape(circle);
            picture.AddShape(triangle);
            
            picture.ShowShapes(picture.collection);
            Console.WriteLine(" <Deleting element by type (Circle)> ");
            picture.DeleteShape(typeof(Circle));
            picture.ShowShapes(picture.collection);
            
            picture.Draw();
            
            Painter painter = new Painter(square);
            
            painter.Draw();

            Console.ReadKey();
        }
    }
}