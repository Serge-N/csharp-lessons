using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Decorator pattern Demo***\n");
            ConcreteComponent cc = new ConcreteComponent();
            ConcreateDecoratorEx1 decorator1 = new ConcreateDecoratorEx1();
            decorator1.SetTheComponent(cc);
            decorator1.MakeHouse();
            ConcreateDecoratorEx2 decorator2 = new ConcreateDecoratorEx2();
            //Adding results from decorator1
            decorator2.SetTheComponent(decorator1);
            decorator2.MakeHouse();
            Console.ReadKey();
        }
    }
    abstract class Component
    {
        public abstract void MakeHouse();
    }
    class ConcreteComponent : Component
    {
        public override void MakeHouse()
        {
            Console.WriteLine("Original house is complete and is closed for modification");
        }
    }
    abstract class AbstractDecorator : Component
    {
        protected Component com;
        public void SetTheComponent (Component c)
        {
            com = c;
        }
        public override void MakeHouse()
        {
            if (com != null)
            {
                com.MakeHouse(); //Delegating the task
            }
        }
    }
    class ConcreateDecoratorEx1 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            base.MakeHouse();
            Console.WriteLine("***Using a decorator***");
            //Decorating now
            AddFloor();
            //Add other stuff as per needs
        }
        private void AddFloor()
        {
            Console.WriteLine("I am making an additional floor on the top of it");
        }
    }
    class ConcreateDecoratorEx2 : AbstractDecorator
    {
        public override void MakeHouse()
        {
            base.MakeHouse();
            Console.WriteLine("***Using another decorator***");
            //Decorating now
            PaintTheHouse();
            //Add other stuff as per needs
        }
        private void PaintTheHouse()
        {
            Console.WriteLine("Now painting the house");
        }
    }

}
