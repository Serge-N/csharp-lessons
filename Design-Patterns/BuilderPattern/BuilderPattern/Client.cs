using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Client
    {
        public Client()
        {
            Console.WriteLine("****Builder Pattern Demo***");
            Director director = new Director();
            IBuilder b1 = new MultipleChoice("A");
            IBuilder b2 = new ShortAnswers("B");
            IBuilder b3 = new Essay("C");
            //Make a multiple choice frame
            Console.WriteLine("\n***Differeent Case ***\n");
            director.Construct(b1);
            Query p1 = b1.GetQuestion();

            //Make short answer frame
            Console.WriteLine("\n***Differeent Case ***\n");
            director.Construct(b2);
            b2.GetQuestion();

            //make an essay frame
            Console.WriteLine("\n***Differeent Case ***\n");
            director.Construct(b3);
            Query p3 = b3.GetQuestion();
            Console.Read();
        }
    }
}
