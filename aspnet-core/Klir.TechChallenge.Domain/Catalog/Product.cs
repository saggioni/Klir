using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Catalog
{
    public class Product
    {
        public Product(int id, string name, int price, int? promotionId = null, string promotionName = null)
        {
            Id = id;
            Name = name;
            Price = price;
            PromotionId = promotionId;
            PromotionName = promotionName;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int? PromotionId { get; private set; }
        public string PromotionName { get; private set; }
    }
}
