using System;

namespace PolicyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Strategy Pattern Demo***\n");
            IChoice ic = null;
            Context cxt = new Context();
            //For simplicity, we are considering 2 user inputs only.
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("\nEnter ur choice(1 or 2)");
                string c = Console.ReadLine();
                if (c.Equals("1"))
                {
                    ic = new FirstChoice();
                }
                else
                {
                    ic = new SecondChoice();
                }
                cxt.SetChoice(ic);
                cxt.ShowChoice();
            }
            Console.ReadKey();
        }
        public interface IChoice 
        {
            public void MyChoice();
        }
        public class SecondChoice : IChoice
        {
            public void MyChoice()
            {
                Console.WriteLine("Traveling to Japan");
            }
        }
        public class FirstChoice : IChoice
        {
            public void MyChoice()
            {
                Console.WriteLine("Traveling to Zambia");
            }
        }
        public class Context 
        {
            IChoice choice;
            public void SetChoice(IChoice choice)
            {
                this.choice = choice;
            }
            public void ShowChoice()
            {
                choice.MyChoice();
            }
        }

    }
}
