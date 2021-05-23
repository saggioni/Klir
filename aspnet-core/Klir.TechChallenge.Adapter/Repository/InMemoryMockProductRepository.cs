using Klir.TechChallenge.Domain.Catalog;
using Klir.TechChallenge.UseCase.Catalog.Port;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Adapter.Repository
{
    public class InMemoryMockProductRepository : IProductRepository
    {
        List<Product> db;

        public InMemoryMockProductRepository()
        {
            db = new List<Product>();
            db.Add(new Product(1, "Product A", 20, 1, "Buy 1 Get 1 Free"));
            db.Add(new Product(2, "Product B", 4, 2, "3 for 10 Euro"));
            db.Add(new Product(3, "Product C", 2));
            db.Add(new Product(4, "Product D", 4, 2, "3 for 10 Euro"));
        }

        public List<Product> Get()
        {
            return db.ToList();
        }

        public Product GetById(int id)
        {
            return db.FirstOrDefault(o => o.Id == id);
        }
    }
}
