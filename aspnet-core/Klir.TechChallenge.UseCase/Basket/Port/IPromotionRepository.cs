using Klir.TechChallenge.Domain.Basket;
using System.Collections.Generic;

namespace Klir.TechChallenge.UseCase.Basket.Port
{
    public interface IPromotionRepository
    {
        Promotion FindPromotionById(int promotionId);
        List<Promotion> FindBasketPromotions(Domain.Basket.Basket basket);
    }
}
