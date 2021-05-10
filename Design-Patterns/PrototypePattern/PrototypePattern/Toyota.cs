using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Toyota : BasicCar
    {
        public Toyota(string name)
        {
            ModelName = name;
        }
        public override BasicCar Clone()
        {
            return (Toyota) this.MemberwiseClone();
        }
    }
    
    
}
