using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Models
{
    public class Snack:Product
    {
        public string Type { get; }
        public DateTime ExpirationDate { get;}
        public string GetExpirationDate()
        {
            return ExpirationDate.ToString("d");
        }
        public double CalorieContentPer100gm { get; }
        private double contentIngm;
        public double ContentIngm
        {
            get { return contentIngm; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("The amount content cannot be less than or zero");
                contentIngm = value;
            }
        }
        public Snack(string name, int price,string tradeMark,string type,double contentIngm, 
             double calorieContentPer100gm, DateTime expirationDate)
            : base(name, price, tradeMark)
        {
            if (double.IsNaN(calorieContentPer100gm))
                throw new ArgumentException("Calorie content can't be null.");
            CalorieContentPer100gm = calorieContentPer100gm;
            ContentIngm = contentIngm;
            Type = type;
            ExpirationDate = expirationDate;

        }
        public override string Examine()
        {
          return $"{Name}\nDescription: It is a {Type} with {ContentIngm} gram and contain {CalorieContentPer100gm} per 100 gm.It is manufactured by {TradeMark}"+
           $"company and expires on {GetExpirationDate()}\nPrice: {Price}";
        }

        public override string Use()
        {
            return "Eat the snack";
        }
    }
}
