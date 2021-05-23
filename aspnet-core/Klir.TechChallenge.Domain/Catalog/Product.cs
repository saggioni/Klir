using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Catalog
{
    public class Product
    {
        public Product() { }
        public Product(int id, string name, int price, int? promotionId = null, string promotionName = null)
        {
            Id = id;
            Name = name;
            Price = price;
            PromotionId = promotionId;
            PromotionName = promotionName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? PromotionId { get; set; }
        public string PromotionName { get; set; }
    }
}
