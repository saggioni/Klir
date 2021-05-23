using Xunit;
using FluentAssertions;
using System.Linq;
using Klir.TechChallenge.Adapter.Repository;
using Klir.TechChallenge.Tests;

namespace KlirTechChallenge.Tests
{
    public class InMemoryMockRepositoryUnitTest
    {
        [Fact]

        public void FindBasketPromotions_ShouldReturnPromotions()
        {
            var repo = new InMemoryMockPromotionRepository();           
            var basket = TestDataHelper.MockBasketPromotion1(10, 2.0, 20.0, 1);

            var promotions = repo.FindBasketPromotions(basket);
            promotions.Should().NotBeNull();
            promotions.Count.Should().Be(1);

            var promotion = promotions.FirstOrDefault(o => o.Id == 1);
            promotion.Should().NotBeNull();
        }

        [Fact]
        public void FindPromotionByProductId_ShouldReturnPromotions()
        {
            var repo = new InMemoryMockPromotionRepository();
            var basket = TestDataHelper.MockBasketPromotion1(10, 2.0, 20.0, 1);

            repo.FindPromotionById(1).Should().NotBeNull();            
            repo.FindPromotionById(2).Should().NotBeNull();

            repo.FindPromotionById(3).Should().BeNull();
            repo.FindPromotionById(999).Should().BeNull();
        }
    }
}
