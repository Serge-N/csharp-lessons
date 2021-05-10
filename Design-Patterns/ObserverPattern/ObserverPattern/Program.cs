using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Observer Pattern Demo***\n");
            //We have 3 observers-2 of them are ObserverType1, 1 of themis of ObserverType2
            IObserver myObserver1 = new ObserverType1("Roy");
            IObserver myObserver2 = new ObserverType1("Kevin");
            IObserver myObserver3 = new ObserverType2("Bose");
            Subject subject = new Subject();
            //Registering the observers-Roy,Kevin,Bose
            subject.Register(myObserver1);
            subject.Register(myObserver2);
            subject.Register(myObserver3);
            Console.WriteLine(" Setting Flag = 5 ");
            subject.Flag = 5;
            //Unregistering an observer(Roy))
            subject.Unregister(myObserver1);
            //No notification this time Roy. Since it is unregistered.
            Console.WriteLine("\n Setting Flag = 50 ");
            subject.Flag = 50;
            //Roy is registering himself again
            subject.Register(myObserver1);
            Console.WriteLine("\n Setting Flag = 100 ");
            subject.Flag = 100;
            Console.ReadKey();
        }
    }

    public interface ISubject
    {
        void NotifyRegisteredUsers(int i);
        void Register(IObserver o);
        void Unregister(IObserver o);
    }
    public interface IObserver
    {
        void Update(int i);
    }

    class ObserverType1: IObserver
    {
        string NameOfObserver;
        public ObserverType1(string name)
        {
            this.NameOfObserver = name;
        }
        public void Update(int i)
        {
            Console.WriteLine($"{NameOfObserver} has recieved an alert: someone has updated myValue to: {i}");
        }
    }
    class ObserverType2 : IObserver
    {
        string NameOfObserver;
        public ObserverType2(string name)
        {
            this.NameOfObserver = name;
        }
        public void Update(int i)
        {
            Console.WriteLine($"{NameOfObserver} notified myValue in subject at: {i}");
        }
    }

    class Subject: ISubject
    {
        List<IObserver> observersList = new List<IObserver>();
        private int flag;
        public int Flag
        {
            get { return flag; }
            set 
            { 
                flag = value;
                NotifyRegisteredUsers(flag);
            }
        }
        public void Register (IObserver observer)
        {
            observersList.Add(observer);
        }
        public void Unregister(IObserver observer)
        {
            observersList.Remove(observer);
        }
        public void NotifyRegisteredUsers(int i)
        {
            foreach (IObserver observer in observersList)
            {
                observer.Update(i);
            }
        }
    }

}
