using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Basket
{
    public class Item
    {
        public Item(int productId, string productName, int quantity, double unitPrice, double totalPrice, int? promotionId = null, string promotionName = null)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            PromotionId = promotionId;
            PromotionName = promotionName;
        }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public double UnitPrice { get; private set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int? PromotionId { get; private set; }
        public string PromotionName { get; set; }
    }
}
