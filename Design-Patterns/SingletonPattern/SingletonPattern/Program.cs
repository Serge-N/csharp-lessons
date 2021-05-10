using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Singleton Demo***\n");
            Console.WriteLine("Trying to create first instance s1.");
            SingletonPatternEx S1 = SingletonPatternEx.Instance;
            Console.WriteLine("Trying to create second instance s2.");
            SingletonPatternEx S2 = SingletonPatternEx.Instance;
            if (S1 == S2) Console.WriteLine("Only one Instance exists");
            else Console.WriteLine("Different instances exist");
        }
    }
}
