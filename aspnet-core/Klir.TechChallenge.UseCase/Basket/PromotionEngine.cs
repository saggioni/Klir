using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.UseCase.Basket.Exceptions;
using Klir.TechChallenge.UseCase.Basket.Port;
using org.mariuszgromada.math.mxparser;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.UseCase.Basket
{
    public class PromotionEngine : IPromotionEngine
    {
        public Domain.Basket.Basket Calc(List<Promotion> promotions, Domain.Basket.Basket basket)
        {
            var calculatedBasket = new Domain.Basket.Basket(basket.CustomerId, basket.CustomerName);

            basket.Items.ForEach(item =>
            {
                this.ResetDiscount(item);
                var itemPromotion = promotions.FirstOrDefault(o => o.Id == item.PromotionId);
                if (itemPromotion != null)
                {
                    int normalItemsCount = item.Quantity % itemPromotion.QuantityToApply;
                    double normalPriceItems = normalItemsCount * item.UnitPrice;

                    int promotionalItemsCount = item.Quantity - normalItemsCount;
                    if (promotionalItemsCount < 0) promotionalItemsCount = 0;

                    try
                    {
                        var discountedPriceItems = new Expression(itemPromotion.Formula.ToLower()
                                                                                .Replace("{promotionalitemscount}", promotionalItemsCount.ToString())
                                                                                .Replace("{unitprice}", item.UnitPrice.ToString())
                                                                                .Replace("{totalprice}", ((double)(item.TotalPrice - normalPriceItems)).ToString()))
                                                                                .calculate();

                        var totalPrice = normalPriceItems + discountedPriceItems;
                        calculatedBasket.Items.Add(new Item(item.ProductId,
                                                            item.ProductName,
                                                            item.Quantity,
                                                            item.UnitPrice,
                                                            totalPrice,
                                                            item.PromotionId,
                                                            discountedPriceItems > 0 ? itemPromotion.Name : null));
                    }
                    catch
                    {
                        throw new PromotionEngineException($"An error occurred when promotion {itemPromotion.Name} was being applied. ProductId: {item.ProductId}");
                    }
                }
                else
                    calculatedBasket.Items.Add(item);
            });

            return calculatedBasket;
        }

        private void ResetDiscount(Item item)
        {
            item.TotalPrice = item.UnitPrice * item.Quantity;
            item.PromotionName = null;
        }
    }
}
