using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Models
{
    public class Vending_machine:IVending
    {
        protected static readonly int[] money = { 1, 5, 10, 20, 50, 100, 500, 1000 };
         public int pay = 0;
        private int depositedAmount;
        public int DepositedAmount
        {
            get { return depositedAmount; }
            set
            { if (value < 0)
                {
                    throw new ArgumentException("Deposited money can't be Zero");
                }
                depositedAmount = value;
            }
        }
        public List<Product> collection;
        public static Dictionary<Product, int> stock = new Dictionary<Product, int>();
        public string EndTransaction()
        {
            int change = DepositedAmount - pay;
            int[] a = new int[money.Length];
            for (int i = 7; i >= 0; i--)
            {
                a[i] = change / money[i];
                change = change % money[i];
            }
            return $"Your change is {a[0]} number of 1kr, {a[1]} number of 5kr, {a[2]} number of 10kr, {a[3]} number of 20kr," +
                $" {a[4]} number of 50kr, {a[5]} number of 100kr, {a[6]} number of 500kr and {a[7]} number of 1000kr";
        }

        // In the main method we ask user  the number of money inserted respectively for each denominator and store it in the amount arrray.
        public string InsertMoney(int[] amount)
        {
            DepositedAmount = 0;
            for (int i = 0; i < money.Length; i++)
            {
                if (amount[i] < 0)
                    throw new ArgumentException("The number of money can not be negative.");
                DepositedAmount = DepositedAmount + (amount[i] * money[i]);
            }
            return $"You have inserted {DepositedAmount}kr in the machine";
        }

        public  string Purchase(Product prod)
        {
            string result;
            if ( stock.ContainsKey(prod) &&  stock[prod] > 0)
            {
                if ((DepositedAmount-pay) >= prod.Price)
                {
                    pay += prod.Price;
                    stock[prod]--;
                    
                    result= $"You have bought {prod.Name}";
                }
                else
                {
                    result= "You don't insert enough money inorder to buy the product";
                }
            }
            else
            {
                throw new KeyNotFoundException("Product has been finshed");
                result= "Sorry, the product has been finished for a while";
            }
            return result;
        }

        public void ShowAll()
        {
            foreach (Product pro in collection)
            {
                if(stock[pro] >0)
                   Console.WriteLine(pro.Name + "\nprice: " + pro.Price);
            }
        }
    }
}
