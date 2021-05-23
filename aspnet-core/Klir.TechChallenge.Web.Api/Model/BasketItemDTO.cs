using Klir.TechChallenge.Domain.Basket;

namespace Klir.TechChallenge.Web.Api.Model
{
    public class BasketItemDTO
    {
        public Basket Basket { get; set; }
        public Item NewItem { get; set; }
    }
}
