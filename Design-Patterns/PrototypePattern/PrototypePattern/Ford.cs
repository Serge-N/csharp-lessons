using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    class Ford : BasicCar
    {
        public Ford(string name)
        {
            ModelName = name;
        }
        public override BasicCar Clone()
        {
            return (Ford) this.MemberwiseClone();
        }
    }
}
