using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public interface IBuilder
    {
        void Presentaion();
        void Input();
        void Comparison();

        Query GetQuestion();
    }
}
