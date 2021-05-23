using Klir.TechChallenge.Adapter.Repository;
using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.UseCase.Basket;
using Klir.TechChallenge.UseCase.Basket.Port;

namespace Klir.TechChallenge.Adapter.Controller
{
    public class BasketController
    {
        private IPromotionRepository repository;
        private IPromotionEngine engine;
        private AddBasketItem useCaseAddBasketItem;

        public BasketController()
        {
            engine = new PromotionEngine();
            repository = new InMemoryMockPromotionRepository();
            useCaseAddBasketItem = new AddBasketItem(engine, repository);
        }
        public Basket AddItem(Basket basket, Item newItem)
        {
            return useCaseAddBasketItem.Add(basket, newItem);
        }
    }
}
