using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem1
{
    public class PhysicalProduct : Product
    {
        private double weight;
        public PhysicalProduct(string name, double price, double weight) : base(name, price)
        {
            this.Weight = weight;
        }
        public double Weight
        {
            get { return this.weight; }
            set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentException("Weight cannot be less or equal to 0!");
                }
                this.weight = value; 
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}" + Environment.NewLine +
                   $"Price: {this.Price}" + Environment.NewLine +
                   $"Weight: {this.Weight}";
        }
    }
}