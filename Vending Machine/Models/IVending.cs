using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine.Models
{
    public interface IVending
    {
         string Purchase(Product prod);
         void ShowAll();
         string InsertMoney(int [] amount);
         string EndTransaction();
    }
}
