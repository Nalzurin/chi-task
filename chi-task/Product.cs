using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace chi_task
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        //Unused but could be useful in case we need to update our price(market changes, inflation)
        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
        public bool TryUpdatePrice(decimal newPrice)
        {
            try
            {
                Price = newPrice;
            }
            catch
            {
                Console.WriteLine("Error, cannot update price.");
                return false;
            }
            return true;
        }

    }
}
