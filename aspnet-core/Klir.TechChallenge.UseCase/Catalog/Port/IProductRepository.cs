using Klir.TechChallenge.Domain.Catalog;
using System.Collections.Generic;

namespace Klir.TechChallenge.UseCase.Catalog.Port
{
    public interface IProductRepository
    {
        List<Product> Get();
        Product GetById(int id);
    }
}
