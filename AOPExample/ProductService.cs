using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOP.Aspect.Attr;

namespace AOPExample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class ProductService : IProductService
    {
        public ProductService()
        {
        }


        [Cache(DurationInMinute = 10000)]
        [Log]
        public Product GetProduct(int productId)
        {
            Dictionary<int, Product> _InMemDb = new Dictionary<int, Product>();
            _InMemDb.Add(1, new Product() { Id = 1, Name = "MacBook Air", Price = 3000 });
            _InMemDb.Add(2, new Product() { Id = 2, Name = "Sony Xperia Z Ultra", Price = 1400 });
            return _InMemDb[productId];
        }
    }

    public interface IProductService
    {
        Product GetProduct(int productId);
    }
}
