using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem1
{
    public class Controller
    {
        private List<Product> products;
        private List<Receipt> receipts;
        public Controller()
        {
            this.products = new List<Product>();
            this.receipts = new List<Receipt>();
        }
        public string ProcessProductCommand(List<string> args)
        {
            products.Add(new PhysicalProduct(args[0], double.Parse(args[1]), double.Parse(args[2])));
            return $"The current customer has bought {args[0]}.";
        }
        public string ProcessServiceCommand(List<string> args)
        {
            products.Add(new ServiceProduct(args[0], double.Parse(args[1]), double.Parse(args[2])));
            return $"The current customer has applied for {args[0]} service.";
        }
        public string ProcessCheckoutCommand(List<string> args)
        {
            var receipt = new Receipt(args[0]);
            this.products.ForEach(p => receipt.AddProduct(p));
            double sumOfProductPrices = products.Sum(x => x.Price);
            this.receipts.Add(receipt);
            this.products = new List<Product>();
            return $"Customer checked out for a total of ${sumOfProductPrices:f2}";
        }
        public string ProcessInfoCommand(List<string> args)
        {
            var sb = new StringBuilder();
            if (args[0] == "Customer")
            {
                sb.AppendLine("Current customer has:");
                sb.AppendLine($"Products: {this.products.Count}");
                sb.AppendLine($"Total Bill: ${this.products.Sum(p => p.Price):f2}");
            }
            else if (args[0] == "Shop")
            {
                if (receipts.Count > 0)
                {
                    sb.AppendLine("Receipts: No receipts");
                }
                else
                {
                    sb.AppendLine($"{string.Join(Environment.NewLine, this.receipts.Select(x => x.ToString()))}");
                }
            }
            return sb.ToString().Trim();
        }
        public string ProcessEndCommand()
        {
            return $"Total customers today: {this.receipts.Count}";
        }
    }
}