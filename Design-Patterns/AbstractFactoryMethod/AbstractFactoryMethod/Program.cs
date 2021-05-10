using System;

namespace AbstractFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Abstract Factory Pattern***");
            //Making a wild dog through wildAnimalFactory
            IAnimalFactory wildAnimalFactory = new WildAnimalFactory();
            IDog wildDog = wildAnimalFactory.GetDog();
            wildDog.Speak();
            wildDog.Action();
            //Making a wild tiger through WildAnimalFactory
            ITiger wildTiger = wildAnimalFactory.GetTiger();
            wildTiger.Speak();
            wildTiger.Action();
            Console.WriteLine("******************");
            //Making a pet dog through PetAnimalFactory
            IAnimalFactory petAnimalFactory = new PetAnimalFactory();
            IDog petDog = petAnimalFactory.GetDog();
            petDog.Speak();
            petDog.Action();
            //Making a pet tiger through PetAnimalFactory
            ITiger petTiger = petAnimalFactory.GetTiger();
            petTiger.Speak();
            petTiger.Action();
            Console.ReadLine();
        }
    }
    public interface IDog
    {
        void Speak();
        void Action();

    }
    public interface ITiger
    {
        void Speak();
        void Action();
    }
    #region Wild Animals Region
    class WildDog : IDog
    {
        public void Speak()
        {
            Console.WriteLine("Wild dog says : Bow-Bow");
        }

        public void Action()
        {
            Console.WriteLine("Wild dogs prefer to roam freely in the jungles\n");
        }
    }
    class WildTiger : ITiger
    {
        public void Speak()
        {
            Console.WriteLine("Wild Tiger says: Haaaa");
        }

        public void Action()
        {
            Console.WriteLine("Wild Tigers prefer hunting in the jungle.\n");
        }
    }
    #endregion
    #region Pet Animals collection
    class PetDog : IDog
    {
        public void Speak()
        {
            Console.WriteLine("Wild dog says : Bow-Bow");
        }

        public void Action()
        {
            Console.WriteLine("Wild dogs prefer to stay at home\n");
        }
    }
    class PetTiger : ITiger
    {
        public void Speak()
        {
            Console.WriteLine("Wild Tiger says: Haaaa");
        }

        public void Action()
        {
            Console.WriteLine("Wild Tigers play in the circus.\n");
        }
    }
    #endregion
    //Abstract factory
    public interface IAnimalFactory
    {
        IDog GetDog();
        ITiger GetTiger();
    }
    //Concreate factories
    public class PetAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new PetDog();
        }
        public ITiger GetTiger()
        {
            return new PetTiger();
        }
    }
    public class WildAnimalFactory : IAnimalFactory
    {
        public IDog GetDog()
        {
            return new WildDog();
        }
        public ITiger GetTiger()
        {
            return new WildTiger();
        }
    }
}


