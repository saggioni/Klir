using Klir.TechChallenge.Domain.Basket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.UseCase.Basket.Port
{
    public interface IPromotionRepository
    {
        Promotion FindPromotionById(int promotionId);
        List<Promotion> FindBasketPromotions(Domain.Basket.Basket basket);
    }
}
