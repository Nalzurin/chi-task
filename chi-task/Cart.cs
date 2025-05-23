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

        public Cart()
        {
            _products = new();
        }
        public Cart(List<Product> products)
        {
            _products = products;
        }
        public Product GetProduct(int id)
        {
            return _products[id];
        }
        public List<Product> GetProducts()
        {
            return _products;
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void AddProduct(string name, decimal price)
        {
            _products.Add(new Product(name, price));
        }
        public void ClearProducts()
        {
            _products.Clear();
        }
        public decimal GetPrice(int id)
        {
            return _products[id].Price;
        }
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
