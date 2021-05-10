using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class Essay : IBuilder
    {
        private string brandName;
        private Query question;
        public Essay(string brand)
        {
            question = new Query();
            this.brandName = brand;
        }
        public void Presentaion()
        {
            Console.WriteLine("Show Question as it is");
        }
        public void Input()
        {
            Console.WriteLine("Allow large space for the editor");
        }
        public void Comparison()
        {
            Console.WriteLine("Use inbuilt offline AI");
        }
        public Query GetQuestion()
        {
            return question;
        }
    }
}
