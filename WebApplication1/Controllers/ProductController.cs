
namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WebApplication1.Models;

    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = GetProducts();
            return View(products);
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
        {
            new Product { ID = 1, Name = "Product 1", Price = 10.99m },
            new Product { ID = 2, Name = "Product 2", Price = 20.49m },
            new Product { ID = 3, Name = "Product 3", Price = 5.99m }
        };
        }
    }

}
