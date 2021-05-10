using System;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Bridge Pattern Demo***");
            Console.WriteLine("\nDealing with a Television:");
            //ElectronicGoods eItem = new Television(presentState);
            ElectronicGoods eItem = new Television();
            IState presentState = new OnState();
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            //Verifying Off state of the Television now
            presentState = new OffState();
            //eItem = new Television(presentState);
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            Console.WriteLine("\n \nDealing with a VCD:");
            presentState = new OnState();
            //eItem = new VCD(presentState);
            eItem = new VCD();
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            presentState = new OffState();
            //eItem = new VCD(presentState);
            eItem.State = presentState;
            eItem.MoveToCurrentState();
            Console.ReadLine();
        }
    }
    public abstract class ElectronicGoods
    {
        protected IState state;
        public IState State { get { return state;  } set { state = value; } }

        public abstract void MoveToCurrentState();
    }

    public interface IState 
    {
        void MoveState();
    }

    class Television: ElectronicGoods
    {
        public override void MoveToCurrentState()
        {
            Console.WriteLine("\nTelevision is functioning at :");
            state.MoveState();
        }
    }

    class VCD: ElectronicGoods
    {
        public override void MoveToCurrentState()
        {
            Console.WriteLine("\nVCD is functioning at :");
            state.MoveState();
        }
    }
    class OffState: IState
    {
        public void MoveState()
        {
            Console.WriteLine("Off State");
        }

    }

    class OnState : IState
    {
        public void MoveState()
        {
            Console.WriteLine("On State");
        }
        
    }
}
