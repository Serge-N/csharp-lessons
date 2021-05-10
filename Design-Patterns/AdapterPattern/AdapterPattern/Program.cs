using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Adapter Pattern Demo ");
            CalculatorAdapter cal = new CalculatorAdapter();
            Triangle t = new Triangle(20, 10);
            Console.WriteLine($"Area of Triangle is {cal.GetArea(t)} square unit");
            Console.ReadKey();
        }
    }
    class Rect
    {
        public double length;
        public double width;
    }
    class Calculator
    {
        public double GetArea(Rect rect)
        {
            return rect.length * rect.width;
        }
    }
    class Triangle
    {
        public double baseT;
        public double height;

        public Triangle(int b, int h)
        {
            this.baseT = b;
            this.height = h;
        }
    }
    class CalculatorAdapter
    {
        public double GetArea(Triangle triangle)
        {
            Calculator c = new Calculator();
            Rect rect = new Rect();
            rect.length = triangle.baseT;
            rect.width = 0.5 * triangle.height;
            return c.GetArea(rect);
        }
    }
}