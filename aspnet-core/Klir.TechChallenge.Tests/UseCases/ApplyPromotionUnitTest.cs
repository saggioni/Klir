using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.UseCase.Basket;
using Klir.TechChallenge.UseCase.Basket.Port;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Klir.TechChallenge.Adapter.Repository;
using Klir.TechChallenge.Tests;

namespace KlirTechChallenge.Tests
{
    public class ApplyPromotionUnitTest
    {
        [Theory]
        [InlineData(2, 10.0, 20.0, 10.0)]
        [InlineData(10, 10.0, 100.0, 50.0)]
        [InlineData(3, 10.0, 30.0, 20.0)]
        [InlineData(5, 10.0, 50.0, 30.0)]
        [InlineData(6, 10.0, 60.0, 30.0)]
        public void ApplyPromotion_Buy2Pay1_ShouldApplyDiscounts(int product1Quantity, double product1UnitPrice, double product1TotalPrice, double product1ExpectedPrice)
        {
            var mockRepo = new InMemoryMockPromotionRepository();
            var promotionEngine = new PromotionEngine();
            var basket = TestDataHelper.MockBasketPromotion1(product1Quantity, product1UnitPrice, product1TotalPrice, 1);            

            var applyPromotionUseCase = new ApplyPromotion(promotionEngine, mockRepo);
            var result = applyPromotionUseCase.Apply(basket);
            result.Should().NotBeNull();
            result.Items.Should().NotBeNull();
            result.Items.Count.Should().Be(2, "Number of items returned in the basket is incorrect.");

            var promotionalItem = result.Items.FirstOrDefault(o => o.ProductId == 1);
            promotionalItem.PromotionName.Should().Be("Buy 2 Pay 1");
            promotionalItem.TotalPrice.Should().Be(product1ExpectedPrice);
            promotionalItem.Quantity.Should().Be(product1Quantity);
        }

        [Theory]
        [InlineData(1, 10.0, 10.0, 10.0)]
        public void ApplyPromotion_Buy2Pay1_ShouldNotApplyDiscounts(int productQuantity, double productUnitPrice, double productTotalPrice, double productExpectedPrice)
        {
            var mockRepo = new InMemoryMockPromotionRepository();
            var promotionEngine = new PromotionEngine();
            var basket = TestDataHelper.MockBasketPromotion1(productQuantity, productUnitPrice, productTotalPrice, 1);

            var applyPromotionUseCase = new ApplyPromotion(promotionEngine, mockRepo);
            var result = applyPromotionUseCase.Apply(basket);
            result.Should().NotBeNull();
            result.Items.Should().NotBeNull();
            result.Items.Count.Should().Be(2, "Number of items returned in the basket is incorrect.");

            var promotionalItem = result.Items.FirstOrDefault(o => o.ProductId == 1);
            promotionalItem.PromotionName.Should().BeNull();
            promotionalItem.TotalPrice.Should().Be(productExpectedPrice);
            promotionalItem.Quantity.Should().Be(productQuantity);
        }


        [Theory]
        [InlineData(10, 4.0, 40.0, 34.0)]
        [InlineData(3, 4.0, 12.0, 10.0)]
        [InlineData(5, 4.0, 20.0, 18.0)]
        [InlineData(6, 4.0, 24.0, 20.0)]
        public void ApplyPromotion_3for10bucks_ShouldApplyDiscounts(int product3Quantity, double product3UnitPrice, double product3TotalPrice, double product3ExpectedPrice)
        {
            var basket = TestDataHelper.MockBasketPromotion2(product3Quantity, product3UnitPrice, product3TotalPrice, 2);

            var mockRepo = new InMemoryMockPromotionRepository();

            var applyPromotionUC = new ApplyPromotion(new PromotionEngine(), mockRepo);
            var result = applyPromotionUC.Apply(basket);
            result.Should().NotBeNull();
            result.Items.Should().NotBeNull();
            result.Items.Count.Should().Be(2);

            var promotionalItem = result.Items.FirstOrDefault(o => o.ProductId == 3);
            promotionalItem.PromotionName.Should().Be("3 for $10");
            promotionalItem.TotalPrice.Should().Be(product3ExpectedPrice);
            promotionalItem.Quantity.Should().Be(product3Quantity);
        }

        [Theory]
        [InlineData(1, 4.0, 4.0, 4.0)]
        [InlineData(2, 4.0, 8.0, 8.0)]
        public void ApplyPromotion_3for10bucks_ShouldNotApplyDiscounts(int productQuantity, double productUnitPrice, double productTotalPrice, double productExpectedPrice)
        {
            var basket = TestDataHelper.MockBasketPromotion2(productQuantity, productUnitPrice, productTotalPrice, 2);

            var mockRepo = new InMemoryMockPromotionRepository();

            var applyPromotionUC = new ApplyPromotion(new PromotionEngine(), mockRepo);
            var result = applyPromotionUC.Apply(basket);
            result.Should().NotBeNull();
            result.Items.Should().NotBeNull();
            result.Items.Count.Should().Be(2);

            var promotionalItem = result.Items.FirstOrDefault(o => o.ProductId == 3);
            promotionalItem.PromotionName.Should().BeNull();
            promotionalItem.TotalPrice.Should().Be(productExpectedPrice);
            promotionalItem.Quantity.Should().Be(productQuantity);
        }
    }
}
