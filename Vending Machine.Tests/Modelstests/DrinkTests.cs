using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Models;
using Xunit;

namespace Vending_Machine.Tests.Modelstests
{
    public class DrinkTests
    {
        [Fact]
        public void Constructor()
        {
            string name = "Pepsi max";
            int price = 10;
            string tradeMark = "PEPSI MAX";
            string type = "Mango flavour";
            double contentInml = 500;
            DateTime expirationDate = new DateTime(2024, 1, 1);
            double calorieContentPer100ml = 33;
            Drink pepsi = null;
            pepsi = new Drink(name, price, tradeMark, type, contentInml, calorieContentPer100ml,expirationDate);
            Assert.NotNull(pepsi);
            Assert.Equal(pepsi.Name, name);
            Assert.Equal(pepsi.Price, price);
            Assert.Equal(pepsi.TradeMark, tradeMark);
            Assert.Equal(pepsi.Type, type);
            Assert.Equal(pepsi.CalorieContentPer100ml, calorieContentPer100ml);
            Assert.Equal(pepsi.ContentInml, contentInml);
            Assert.Equal(pepsi.ExpirationDate,expirationDate);
        }
        [Fact]
        public void UseTest()
        {
            string name = "Pepsi max";
            int price = 10;
            string tradeMark = "PEPSI MAX";
            string type = "Mango flavour";
            double contentInml = 500;
            DateTime expirationDate = new DateTime(2024, 1, 1);
            double calorieContentPer100ml = 33;
            Drink pepsi = null;
            pepsi = new Drink(name, price, tradeMark, type, contentInml, calorieContentPer100ml, expirationDate);
            Assert.Equal("Drink the drink", pepsi.Use());
        }
        [Fact]
        public void ExamineTest()
        {
            string name = "Pepsi max";
            int price = 10;
            string tradeMark = "PEPSI MAX";
            string type = "Mango flavour";
            double contentInml = 330;
            DateTime expirationDate = new DateTime(2024, 1, 1);
            double calorieContentPer100ml = 33;
            Drink pepsi = null;
            pepsi = new Drink(name, price, tradeMark, type, contentInml, calorieContentPer100ml, expirationDate);
            Assert.Equal("Pepsi max\nDescription: It is a Mango flavour with 330 ml and contain 33 calorie per 100 ml." +
                "It is manufactured by PEPSI MAX" +
           $"company and expires on {pepsi.GetExpirationDate()}\nPrice: 10", pepsi.Examine());
        }
        [Fact]
        public void CheckContentInml()
        {
            string name = "Pepsi max";
            int price = 10;
            string tradeMark = "PEPSI MAX";
            string type = "Mango flavour";
            double contentInml = 0;
            DateTime expirationDate = new DateTime(2024, 1, 1);
            double calorieContentPer100ml = 33;
            ArgumentException result= Assert.Throws<ArgumentException>(()=> new Drink(name, price, tradeMark, type,
                contentInml,calorieContentPer100ml, expirationDate));
            Assert.Equal("The liter content cannot be less than or zero",result.Message);
        }
    }
}
