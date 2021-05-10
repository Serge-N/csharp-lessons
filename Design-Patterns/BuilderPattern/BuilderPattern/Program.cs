using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Builder Pattern Demo***");
            Director director = new Director();
            IBuilder b1 = new Car("Ford");
            IBuilder b2 = new MotorCycle("Honda");
            //Make a car
            director.Construct(b1);
            Product p1 = b1.GetVechicle();
            p1.Show();
            //Make MotorCycle
            director.Construct(b2);
            Product p2 = b2.GetVechicle();
            p2.Show();
            Console.Read();
        }
        //Builders common interface
        interface IBuilder
        {
            void StartUpOperations();
            void BuildBody();
            void InsertWheels();
            void AddHeadlights();
            void EndOperations();
            Product GetVechicle();
        }
        //concreteBuilder: Car
        class Car: IBuilder
        {
            private string brandName;
            private Product product;
            public Car(string brand)
            {
                product = new Product();
                this.brandName = brand;
            }
            public void StartUpOperations()
            {
                //starting with brandname
                product.Add(String.Format($"Car Model Name : {this.brandName}"));
            }
            public void BuildBody()
            {
                product.Add("This is the body of a Car");
            }
            public void InsertWheels()
            {
                product.Add("4 Wheels are added");
            }
            public void AddHeadlights()
            {
                product.Add("2 Headlights are added");
            }
            public void EndOperations()
            {
                //nothing here
            }
            public Product GetVechicle()
            {
                return product;
            }
        }
        //concreteBuilder: Motorcycle
        class MotorCycle : IBuilder
        {
            private string brandName;
            private Product product;
            public MotorCycle (string brand)
            {
                product = new Product();
                this.brandName = brand;
            }
            public void StartUpOperations()
            {
                //starting with brandname
            }
            public void BuildBody()
            {
                product.Add("This is the body of a Motercycle");
            }
            public void InsertWheels()
            {
                product.Add("2 Wheels are added");
            }
            public void AddHeadlights()
            {
                product.Add("1 Headlight is added");
            }
            public void EndOperations()
            {
                //finishing with a brandname
                product.Add(String.Format($"Motorcycle Model Name : {this.brandName}"));
            }
            public Product GetVechicle()
            {
                return product;
            }
        }
        //"Product"
        class Product
        {
            private List<string> parts;
            public Product()
            {
                parts = new List<string>();
            }
            public void Add(string part)
            {
                parts.Add(part);
            }
            public void Show()
            {
                Console.WriteLine("\nProduct completed as below :");
                foreach (string part in parts)
                    Console.WriteLine(part);
            }
        }
        //"Director"
        class Director
        {
            IBuilder builder;
            //A series of complex steps in real life
            public void Construct (IBuilder builder)
            {
                this.builder = builder;
                builder.StartUpOperations();
                builder.BuildBody();
                builder.InsertWheels();
                builder.AddHeadlights();
                builder.EndOperations();
            }
        }
    }
}
