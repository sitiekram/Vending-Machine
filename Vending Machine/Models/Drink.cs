using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Models
{
    public class Drink : Product
    {
        public DateTime ExpirationDate { get; }
        public string GetExpirationDate()
        {
            return ExpirationDate.ToString("d");
        }
        public string Type { get; }
        public double CalorieContentPer100ml { get; }
        private double contentInml;
        public double ContentInml { get { return contentInml; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("The liter content cannot be less than or zero");
                contentInml = value;
            } }
        public Drink(string name,int price,string tradeMark,string type,double contentInml,
            double calorieContentPer100ml, DateTime expirationDate)
            :base(name,price,tradeMark)
        {
            if (double.IsNaN(calorieContentPer100ml))
                throw new ArgumentException("Calorie content can't be null.");

            CalorieContentPer100ml = calorieContentPer100ml;
            Type = type;
            ContentInml = contentInml;
            ExpirationDate = expirationDate;
        }
        public override string Examine()
        {
            return $"{Name}\nDescription: It is a {Type} with {ContentInml} ml and contain {CalorieContentPer100ml} calorie per 100 ml.It is manufactured by {TradeMark}"+
                 $"company and expires on {GetExpirationDate()}\nPrice: {Price}";
        }

        public override string Use()
        {
            return "Drink the drink";
        }
    }
}
