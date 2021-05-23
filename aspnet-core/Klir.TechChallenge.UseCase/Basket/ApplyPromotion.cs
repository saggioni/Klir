using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.UseCase.Basket.Port;
using System;

namespace Klir.TechChallenge.UseCase.Basket
{
    public class ApplyPromotion
    {
        private IPromotionEngine engine;
        private IPromotionRepository promotionRepository;

        public ApplyPromotion(IPromotionEngine engine, IPromotionRepository promotionRepository)
        {
            this.engine = engine;
            this.promotionRepository = promotionRepository;
        }
        public Domain.Basket.Basket Apply(Domain.Basket.Basket basket)
        {
            var promotions = promotionRepository.FindBasketPromotions(basket);
            if (promotions == null || promotions.Count <= 0) return basket;

            return engine.Calc(promotions, basket);
        }
    }
}
