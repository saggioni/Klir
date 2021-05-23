using FluentAssertions;
using Klir.TechChallenge.Tests;
using Klir.TechChallenge.UseCase.Basket;
using System;
using System.Linq;
using Xunit;
using Moq;
using Klir.TechChallenge.UseCase.Basket.Port;

namespace KlirTechChallenge.Tests
{
    public class PromotionEngineUnitTest
    {
        [Theory]
        [InlineData(2, 10.0, 20.0, 10.0)]
        [InlineData(10, 10.0, 100.0, 50.0)]
        [InlineData(3, 10.0, 30.0, 20.0)]
        [InlineData(5, 10.0, 50.0, 30.0)]
        public void Calc_WithCorrectValues_ShouldReturnPromotions(int quantity, double unitPrice, double totalPrice, double expectedPrice)
        {
            var basket = TestDataHelper.MockBasketPromotion1(quantity, unitPrice, totalPrice, 1);
    
            var mockRepo = new Mock<IPromotionRepository>();
            mockRepo.Setup(o => o.FindBasketPromotions(basket)).Returns(TestDataHelper.MockPromotions());
            var promotions = mockRepo.Object.FindBasketPromotions(basket);

            var engine = new PromotionEngine();
            var result = engine.Calc(promotions, basket);
            result.Should().NotBeNull();

            var promotionApplied = result.Items.FirstOrDefault(o => o.PromotionName != null);
            promotionApplied.Should().NotBeNull();
            promotionApplied.Quantity.Should().Be(quantity);
            promotionApplied.UnitPrice.Should().Be(unitPrice);
            promotionApplied.TotalPrice.Should().Be(expectedPrice);
        }
    }
}
