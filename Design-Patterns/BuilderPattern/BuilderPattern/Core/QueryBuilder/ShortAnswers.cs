using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    class ShortAnswers : IBuilder
    {
        private string brandName;
        private Query question;
        public ShortAnswers(string brand)
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
            Console.WriteLine("Determine if the input required is single if not create a list of entrys");
        }
        public void Comparison()
        {
            Console.WriteLine("Advanced logic use array compasion for multiple entries, such for key words");
        }
        public Query GetQuestion()
        {
            return question;
        }
    }
}
