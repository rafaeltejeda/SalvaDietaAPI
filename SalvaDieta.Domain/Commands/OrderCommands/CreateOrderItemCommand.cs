using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Commands.OrderCommands
{
    public class CreateOrderItemCommand
    {
        public CreateOrderItemCommand(int quantity, decimal price, string weight, int product)
        {
            this.Quantity = quantity;
            this.Price = price;
            this.Weight = weight;
            this.Product = product;
        }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Weight { get; private set; }
        public int Product { get; set; }

    }
}
