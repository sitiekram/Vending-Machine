using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Vending_Machine.Models;

namespace Vending_Machine.Tests.Modelstests
{
    public class ToyTests
    {
        [Fact]
        public void CheckPrice()
        {
            string name = "Barbie";
            int price =-1;
            string tradeMark = "Nest";
            string ManufacturedCountry = "USA";
            string type = "doll";
            ArgumentException ex = Assert.Throws<ArgumentException>(()=> new Toy(name, price, tradeMark, ManufacturedCountry, type));
            Assert.Equal("Price cannot be less than or zero", ex.Message);
            //
        }
        [Fact]
        public void CheckName()
        {
            string name = "";
            int price = 100;
            string tradeMark = "Nest";
            string ManufacturedCountry = "USA";
            string type = "doll";
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Toy(name, price, tradeMark, ManufacturedCountry, type));
            Assert.Equal("Name cant be null or empty.", ex.Message);
        }
        [Fact]
        public void Constructor()
        {
            string name = "Barbie";
            int price = 100;
            string tradeMark = "Nest";
            string manufacturedCountry = "USA";
            string type = "doll";
            Toy barbie = null;
            barbie = new Toy(name, price, tradeMark, manufacturedCountry, type);
            Assert.NotNull(barbie);
            Assert.Equal(barbie.Name,name);
            Assert.Equal(barbie.Price,price);
            Assert.Equal(barbie.TradeMark,tradeMark);
            Assert.Equal(barbie.Type,type);
        }
        [Fact]
        public void UseTest()
        {
            Product barbie = new Toy("Barbie", 100, "Nest", "USA", "doll");
            Assert.Equal("Play with toy",barbie.Use());
        }
        [Fact]
        public void ExamineTest()
        {
            string name = "Barbie";
            int price = 100;
            string tradeMark = "Nest";
            string manufacturedCountry = "USA";
            string type = "doll";
            Toy barbie = null;
            barbie = new Toy(name, price, tradeMark, manufacturedCountry, type);
            Assert.Equal("Barbie\nDescription: It is a doll which is manufactured by Nest company that is located in " +
                "USA country.\nPrice: 100", barbie.Examine());
        }

    }
}
