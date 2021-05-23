using Klir.TechChallenge.Domain.Basket;
using System.Collections.Generic;

namespace Klir.TechChallenge.UseCase.Basket.Port
{
    public interface IPromotionEngine
    {
        Klir.TechChallenge.Domain.Basket.Basket Calc(List<Promotion> promotions, Klir.TechChallenge.Domain.Basket.Basket basket);
    }
}
