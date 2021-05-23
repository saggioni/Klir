using Klir.TechChallenge.Adapter.Repository;
using Klir.TechChallenge.Domain.Catalog;
using Klir.TechChallenge.UseCase.Catalog;
using Klir.TechChallenge.UseCase.Catalog.Port;
using System.Collections.Generic;

namespace Klir.TechChallenge.Adapter.Controller
{
    public class CatalogController
    {
        private IProductRepository repository;
        private GetProducts useCaseGetProducts;

        public CatalogController()
        {
            repository = new InMemoryMockProductRepository();
            useCaseGetProducts = new UseCase.Catalog.GetProducts(repository);
        }
        public List<Product> GetProducts()
        {
            return useCaseGetProducts.GetAll();
        }
    }
}
