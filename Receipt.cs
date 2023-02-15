using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem1
{
    public class Receipt
    {
        private string customerName;
        List<Product> products;
        public string CustomerName 
        { 
            get { return this.customerName; } 
            set 
            { 
                if(value.Length < 2 && value.Length > 40)
                {
                    throw new ArgumentException("Customer Name should be between 2 and 40 characters!");
                }
                this.customerName = value;
            } 
        }
        public Receipt(string customerName)
        {
            this.CustomerName = customerName;
            this.products = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }
        public override string ToString()
        {
            return $"Receipt of {this.CustomerName}" + Environment.NewLine +
                   $"Total Price: {this.products.Sum(x => x.Price)}" + Environment.NewLine +
                   $"Products: {this.products.Select(x => x.ToString())}" + Environment.NewLine;
        }
    }
}