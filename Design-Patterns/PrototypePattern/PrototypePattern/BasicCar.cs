using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public abstract class BasicCar
    {
        public string ModelName { get; set; }
        public int Price { get; set; }
        public static int SetPrice()
        {
            int price = 0;
            Random Interger = new Random();
            price = Interger.Next(20000, 40000);
            return price;
        }
        public abstract BasicCar Clone();
    }
}
