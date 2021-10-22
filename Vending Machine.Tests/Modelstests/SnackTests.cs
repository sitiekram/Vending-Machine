using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Vending_Machine.Models;
namespace Vending_Machine.Tests.Modelstests
{
    public class SnackTests
    {
        [Fact]
        public void Constructor()
        {
            string name = "Twix";
            int price = 10;
            string tradeMark = "TWIX";
            string type = "Chocaolate";
            double calorieContentPer100gm = 500;
            double contentIngm = 100;
            Snack twix = null;
            twix = new Snack(name, price, tradeMark, type, contentIngm, calorieContentPer100gm,new DateTime(2023,1,2));
            Assert.NotNull(twix);
            Assert.Equal(twix.Name, name);
            Assert.Equal(twix.Price, price);
            Assert.Equal(twix.TradeMark, tradeMark);
            Assert.Equal(twix.Type, type);
            Assert.Equal(twix.CalorieContentPer100gm, calorieContentPer100gm);
            Assert.Equal(twix.ContentIngm, contentIngm);
            Assert.Equal(twix.ExpirationDate,new DateTime(2023, 1, 2));
        }
        [Fact]
        public void UseTest()
        {
            string name = "Twix";
            int price = 10;
            string tradeMark = "TWIX";
            string type = "Chocaolate";
            double calorieContentPer100gm = 500;
            double contentIngm = 100;
            Snack twix = null;
            twix = new Snack(name, price, tradeMark, type, contentIngm, calorieContentPer100gm,new DateTime(2023, 1, 2));
            Assert.Equal("Eat the snack", twix.Use());
        }
        [Fact]
        public void ExamineTest()
        {
            string name = "Twix";
            int price = 10;
            string tradeMark = "TWIX";
            string type = "chocaolate";
            double calorieContentPer100gm = 500;
            double contentIngm = 100;
            Snack twix = null;
            twix = new Snack(name, price, tradeMark, type, contentIngm, calorieContentPer100gm, new DateTime(2023, 1, 2));
            Assert.Equal("Twix\nDescription: It is a chocaolate with 100 gram and contain 500 per 100 gm.It is manufactured by TWIX" +
           $"company and expires on {twix.GetExpirationDate()}\nPrice: 10", twix.Examine());
        }
    }
    }
