using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class MultipleChoice : IBuilder
    {
        private string brandName;
        private Query question;
        public MultipleChoice(string brand)
        {
            question = new Query();
            this.brandName = brand;
        }
        public void Presentaion()
        {
            Console.WriteLine("slit into multiple parts and assign int radio parts");
        }
        public void Input()
        {
            Console.WriteLine("Using radio buttons as assigned above.");
        }
        public void Comparison()
        {
            Console.WriteLine("Using dummy commparison of letters, === or compares to");
        }
        public Query GetQuestion()
        {
            return question;
        }
    }
}
