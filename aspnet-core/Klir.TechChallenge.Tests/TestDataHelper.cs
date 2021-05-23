using Klir.TechChallenge.Domain.Basket;
using System.Collections.Generic;

namespace Klir.TechChallenge.Tests
{
    public static class TestDataHelper
    {
        public static Basket MockBasketPromotion1(int product1Quantity, double product1UnitPrice, double product1TotalPrice, int promotionId)
        {
            var basket = new Basket(1, "Customer1");
            basket.Items.Add(new Item(1, "Product1", product1Quantity, product1UnitPrice, product1TotalPrice, promotionId));
            basket.Items.Add(new Item(2, "Product2", 3, 2.5, 7.5));

            return basket;
        }

        public static Basket MockBasketPromotion2(int product3Quantity, double product3UnitPrice, double product3TotalPrice, int promotionalId)
        {
            var basket = new Basket(1, "Customer1");
            basket.Items.Add(new Item(2, "Product2", 3, 2.5, 7.5));
            basket.Items.Add(new Item(3, "Product3", product3Quantity, product3UnitPrice, product3TotalPrice, promotionalId));

            return basket;
        }

        public static List<Promotion> MockPromotions()
        {
            var result = new List<Promotion>();
            result.Add(new Promotion(1, "Buy 2 Pay 1", "{totalprice} * 0.5", 2));
            result.Add(new Promotion(2, "3 for $10", "({promotionalitemscount} / 3) * 10", 3));

            return result;
        }
    }
}
