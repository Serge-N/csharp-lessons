using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Prototype Pattern Demo***\n");
            //Base or Original copy
            BasicCar toyota_base = new Toyota("Land Crusor") {Price=10000};
            BasicCar ford_base = new Ford("Pickup D4D") { Price = 400000 };
            BasicCar car1;
            //Toyota
            car1 = toyota_base.Clone();
            car1.Price = toyota_base.Price + BasicCar.SetPrice();
            Console.WriteLine($"Car is {car1.ModelName}, and its price is {car1.Price} ZMW");
            //Ford
            car1 = ford_base.Clone();
            car1.Price = ford_base.Price + BasicCar.SetPrice();
            Console.WriteLine($"Car is {car1.ModelName}, and its price is {car1.Price} ZMW");
        }
    }
}
