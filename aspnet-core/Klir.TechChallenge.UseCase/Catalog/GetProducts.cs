using Klir.TechChallenge.Domain.Catalog;
using Klir.TechChallenge.UseCase.Catalog.Port;
using System.Collections.Generic;

namespace Klir.TechChallenge.UseCase.Catalog
{
    public class GetProducts
    {
        private IProductRepository productRepository;

        public GetProducts(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return productRepository.Get();
        }
    }
}
