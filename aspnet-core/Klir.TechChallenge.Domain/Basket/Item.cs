using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Basket
{
    public class Item
    {
        public Item() { }
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

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public int? PromotionId { get; set; }
        public string PromotionName { get; set; }
    }
}
