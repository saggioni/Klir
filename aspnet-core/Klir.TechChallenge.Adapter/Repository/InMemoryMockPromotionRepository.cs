using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.UseCase.Basket.Port;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Klir.TechChallenge.Adapter.Repository
{
    public class InMemoryMockPromotionRepository : IPromotionRepository
    {
        List<Promotion> db;

        public InMemoryMockPromotionRepository()
        {
            db = new List<Promotion>();
            db.Add(new Promotion(1, "Buy 2 Pay 1", "{totalprice} * 0.5", 2));
            db.Add(new Promotion(2, "3 for $10", "({promotionalitemscount} / 3) * 10", 3));
        }

        public List<Promotion> FindBasketPromotions(Basket basket)
        {
            List<Promotion> promotions = new List<Promotion>();
            basket.Items.ForEach(basketItem =>
            {
                if (basketItem.PromotionId.HasValue)
                {
                    var promotion = FindPromotionById(basketItem.PromotionId.Value);
                    if (promotion != null)
                        promotions.Add(promotion);
                }
            });

            return promotions;
        }

        public Promotion FindPromotionById(int promotionId)
        {
           return db.FirstOrDefault(promotionItem => promotionId == promotionItem.Id);
        }
    }
}
