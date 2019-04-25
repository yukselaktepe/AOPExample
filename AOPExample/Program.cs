using AOP.Aspect;
using System;
using System.Threading;

namespace AOPExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = TransparentProxy<ProductService, IProductService>.GenerateProxy();

            var product = productService.GetProduct(1);

            Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", product.Id, product.Name, product.Price);

            Thread.Sleep(10000);
            var caching = productService.GetProduct(1);

            Console.WriteLine("Id: {0}, Name: {1}, Price: {2}", caching.Id, caching.Name, caching.Price);
            Console.ReadLine();
        }
    }
}
