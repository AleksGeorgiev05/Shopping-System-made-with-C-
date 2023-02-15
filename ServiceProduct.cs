using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem1
{
    public class ServiceProduct : Product
    {
        private double time;
        public ServiceProduct(string name, double price, double time) : base(name, price)
        {
            this.Time = time;
        }
        public double Time
        {
            get { return this.time; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Time should be greater than 0!");
                }
                this.time = value; 
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}" + Environment.NewLine +
                   $"Price: {this.Price}" + Environment.NewLine +
                   $"Time: {this.Time}";
        }
    }
}