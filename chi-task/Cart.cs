using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chi_task
{
    public class Cart
    {
        private List<Product> _products;

        //Constructors, one with list parameter in case we have a premade list from a different source
        public Cart()
        {
            _products = new();
        }
        public Cart(List<Product> products)
        {
            _products = new(products);
        }

        //Returns products
        public List<Product> GetProducts()
        {
            return _products;
        }
        //Adds new item to the list
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        //Clears the list
        public void ClearProducts()
        {
            _products.Clear();
        }
        //Gets the total amount of all items in the cart
        public decimal GetTotalAmount()
        {
            decimal result = 0;
            foreach(Product product in _products)
            {
                result += product.Price;
            }
            return result;
        }
    }
}
