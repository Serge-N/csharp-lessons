using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern.RobotParts
{
    public class RobotBody
    {
        public void createHands()
        {
            Console.WriteLine("Hands manufactured");
        }
        public void CreateRemaingParts()
        {
            Console.WriteLine("Remaining Parts (other than hands) are created");
        }
        public void DestroyHands()
        {
            Console.WriteLine("The robot's hands are destroyed");
        }
        public void DestroyRemainingParts()
        {
            Console.WriteLine("The robot's remaing parts are destroyed");
        }
    }
}
