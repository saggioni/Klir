using Klir.TechChallenge.Adapter.Controller;
using Klir.TechChallenge.Domain.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private CatalogController adapterController = new CatalogController();

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return adapterController.GetProducts();
        }
    }
}
