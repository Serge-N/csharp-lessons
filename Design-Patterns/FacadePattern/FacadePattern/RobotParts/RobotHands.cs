using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.RobotParts
{
    public class RobotHands
    {
        public void SetMilanoHands()
        {
            Console.WriteLine("The robot will have EH1 Milano hands");
        }
        public void SetRobonautHands()
        {
            Console.WriteLine("The Robot will have Robonaut Hands");
        }
        public void ResetMilanoHands() 
        {
            Console.WriteLine("EH1 Milano hands are about to be destroyed");
        }
        public void ResetRobonautHands()
        {
            Console.WriteLine("Robonaut hands are about to be destroyed");
        }
    }
}
