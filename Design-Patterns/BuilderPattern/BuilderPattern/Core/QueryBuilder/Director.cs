using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Director
    {
            IBuilder builder;
            //A series of complex steps in real life
            public void Construct(IBuilder builder)
            {
                this.builder = builder;
                builder.Presentaion();
                builder.Input();
                builder.Comparison();
            }
    }
    
}
