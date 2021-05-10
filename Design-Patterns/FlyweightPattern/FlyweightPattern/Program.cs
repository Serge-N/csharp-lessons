using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    interface IRobot
    {
        void Print();
    }
    class SmallRobot : IRobot
    {
        public void Print()
        {
            Console.WriteLine("This is a small Robot");
        }
    }
    class LargeRobot : IRobot
    {
        public void Print()
        {
            Console.WriteLine("This is a large Robot");
        }
    }
    class RobotFactory
    {
        Dictionary <string, IRobot> shapes= new Dictionary<string, IRobot>();
        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }
        public IRobot GetRobotFromFactory (string robotType)
        {
            IRobot robotCategory = null;
            if (shapes.ContainsKey(robotType))
                robotCategory = shapes[robotType];
            else
            {
                switch (robotType)
                {
                    case "Small":
                        robotCategory = new SmallRobot();
                        shapes.Add("Small", robotCategory);
                        break;
                    case "Large":
                        robotCategory = new LargeRobot();
                        shapes.Add("Large", robotCategory);
                        break;
                    default:
                        throw new Exception("Robot Factory can create only small and large robots");
                }
            }
            return robotCategory;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Flyweight Pattern Demo***\n");
            RobotFactory myfactory = new RobotFactory();
            IRobot shape = myfactory.GetRobotFromFactory("Small");
            shape.Print();
            
            for (int i = 0; i < 2; i++)
            {
                shape = myfactory.GetRobotFromFactory("Small");
                shape.Print();
            }

            int NumOfDistinctRobots = myfactory.TotalObjectsCreated;
            Console.WriteLine($"\n Now, total numbers of distinct robot objects is = {NumOfDistinctRobots}\n");

            for (int i = 0; i < 5; i++)
            {
                shape = myfactory.GetRobotFromFactory("Large");
                shape.Print();
            }
            NumOfDistinctRobots = myfactory.TotalObjectsCreated;
            Console.WriteLine($"\n Distinct Robot objects created till now = {NumOfDistinctRobots} ");
            Console.ReadKey();
        }
    }
}
