using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{
    public sealed class SingletonPatternEx
    {
        private static readonly SingletonPatternEx instance = new SingletonPatternEx();
        private int numberOfInstances = 0;

        private SingletonPatternEx()
        {
            Console.WriteLine("Instantiating inside the private constructor.");
            numberOfInstances++;
            Console.WriteLine($"Number of instances = {numberOfInstances}");
        }
        public static SingletonPatternEx  Instance
        {
            get 
            {
                Console.WriteLine("We already have an  instance now. Use it");
                return instance;
            }
        }
    }
}
