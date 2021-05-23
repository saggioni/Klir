using Klir.TechChallenge.Domain.Basket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.UseCase.Basket.Port
{
    public interface IPromotionEngine
    {
        Klir.TechChallenge.Domain.Basket.Basket Calc(List<Promotion> promotions, Klir.TechChallenge.Domain.Basket.Basket basket);
    }
}
