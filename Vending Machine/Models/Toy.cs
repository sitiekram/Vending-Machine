using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Models
{
    public class Toy :Product
    {
        public string Type { get;}
        public string ManufacturedCountry { get; }
        public Toy(string name, int price, string tradeMark, string manufacturedCountry ,string type)
            : base(name, price, tradeMark)
        {
            Type = type;
            ManufacturedCountry = manufacturedCountry;
        }
        public override string Examine()
        {
             return $"{Name}\nDescription: It is a {Type} which is manufactured by {TradeMark} company that is located in " +
                $"{ManufacturedCountry} country.\nPrice: {Price}";
        }

        public override string Use()
        {
            return "Play with toy";
        }
    }
}
