using Klir.TechChallenge.Domain.Basket;
using Klir.TechChallenge.Web.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private Adapter.Controller.BasketController adapterController = new Adapter.Controller.BasketController();

        [HttpPost]
        public Basket AddItem(BasketItemDTO request)
        {
            return adapterController.AddItem(request.Basket, request.NewItem);
        }
    }


}
