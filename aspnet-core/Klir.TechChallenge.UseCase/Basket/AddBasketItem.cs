using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.UseCase.Basket.Port;
using System.Linq;

namespace Klir.TechChallenge.UseCase.Basket
{
    public class AddBasketItem
    {
        private IPromotionEngine engine;
        private IPromotionRepository promotionRepository;

        public AddBasketItem(IPromotionEngine engine, IPromotionRepository promotionRepository)
        {
            this.engine = engine;
            this.promotionRepository = promotionRepository;
        }

        public Domain.Basket.Basket Add(Domain.Basket.Basket basket, Item newItem)
        {
            var basketItem = basket.Items.FirstOrDefault(o => o.ProductId == newItem.ProductId);
            if (basketItem != null)
                basketItem.Quantity++;
            else
                basket.Items.Add(newItem);

            var useCaseApplyPromotion = new ApplyPromotion(engine, promotionRepository);
            return useCaseApplyPromotion.Apply(basket);
        }
    }
}
