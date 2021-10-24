using System;
using System.Collections.Generic;
using System.Text;
using Vending_Machine.Models;
using Xunit;
namespace Vending_Machine.Tests.Modelstests
{
    public class Vending_machineTests
    {
        [Fact]
        public void InsertMoneyTest()
        {
            Vending_machine vm = new Vending_machine();
            int[] amount = { 0, 2, 1, 1, 2, 3, 1, 0 };
            string result = vm.InsertMoney(amount);
            Assert.Equal("You have inserted 940kr in the machine", result);
        }
        [Fact]
        public void NegativeAmountInsertTest()
        {
            Product barbie = new Toy("Barbie", 100, "Nest", "USA", "doll");
            Vending_machine vm = new Vending_machine();
            Vending_machine.stock.Add(barbie, 5);
            int[] amount = { 0, -2, 1, 1, 2, 3, -1, 0 };
            ArgumentException result= Assert.Throws<ArgumentException>(()=> vm.InsertMoney(amount));
            Assert.Equal("The number of money can not be negative.", result.Message);
        }

        [Fact]
        public void PurchaseTest()
        {
            Product barbie = new Toy("Barbie",100,"Nest","USA", "doll");
            Vending_machine vm = new Vending_machine();
            Vending_machine.stock.Add(barbie, 5);
            vm.DepositedAmount = 300;
            string result = vm.Purchase(barbie);
            Assert.Equal("You have bought Barbie", result);
        }
        [Fact]
        public void CheckProductExist()
        {
            Product barbie = new Toy("Barbie", 100, "Nest", "USA", "doll");
            Vending_machine vm = new Vending_machine();
            //Vending_machine.stock.Add(barbie, 0);
            vm.DepositedAmount = 300;
            KeyNotFoundException result= Assert.Throws<KeyNotFoundException>(()=> vm.Purchase(barbie));
            Assert.Equal("Product has been finshed",result.Message);
        }
        
        [Fact]
        public void DoesHaveEnoughMoney()
        {
            Product barbie = new Toy("Barbie", 100, "Nest", "USA", "doll");
            Vending_machine vm = new Vending_machine();
            Vending_machine.stock.Add(barbie, 5);
            vm.DepositedAmount = 10;
            string result = vm.Purchase(barbie);
            Assert.Equal("You don't insert enough money inorder to buy the product", result);
        }
        [Fact]
        public void EndTransaction()
        {
            Product barbie = new Toy("Barbie", 100, "Nest", "USA", "doll");
            Product candybar = new Snack("Candybar",15,"Nes","Candy",100,300, new DateTime(2023, 1, 2));
            Vending_machine vm = new Vending_machine();
            Vending_machine.stock.Add(barbie, 5);
            Vending_machine.stock.Add(candybar,10);
            vm.DepositedAmount = 500;
            vm.Purchase(barbie);
            vm.Purchase(candybar);
            string result = vm.EndTransaction();
            Assert.Equal($"Your change is 0 number of 1kr, 1 number of 5kr, 1 number of 10kr, 1 number of 20kr," +
                $" 1 number of 50kr, 3 number of 100kr, 0 number of 500kr and 0 number of 1000kr", result);
        }
    }
}
