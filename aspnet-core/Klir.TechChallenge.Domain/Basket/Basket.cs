using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Basket
{
    public class Basket
    {
        public Basket(int customerId, string customerName)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            Items = new List<Item>();
        }
        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public List<Item> Items { get; set; }

    }
}
