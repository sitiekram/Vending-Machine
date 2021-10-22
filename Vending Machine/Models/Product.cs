using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Models
{
    abstract public class Product
    { 
        private int price;
        public string Name { get; }
        public string TradeMark { get; }
        public abstract string Examine();
        public abstract string Use();
        public Product(string name, int price,string tradeMark)
        {
            if (string.IsNullOrEmpty(name))
               throw new ArgumentException("Name cant be null or empty.");
            //if (string.IsNullOrEmpty(TradeMark))
                //throw new ArgumentException("The trade mark name cant be null or empty.");
            Name = name;
            Price = price;
            TradeMark = tradeMark;
        }
        public int Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Price cannot be less than or zero");
                else
                    price = value;
            }
        }

        public string SetPrice(int price)
        {
            int oldPrice = Price;
            Price = price;
            return $"Replaced old price:{oldPrice}, with new price: {Price}";
        }


    }
}
