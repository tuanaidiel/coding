//Controller

using Microsoft.AspNetCore.Mvc;
using ShopApp.Models;
using System.Collections.Generic;

namespace ShopApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product{Id=1, Name="Laptop", Price = 999.99m},
                new Product{Id=2, Name="Smartphone", Price= 499.99m},
                new Product{Id=3, Name="Headphone", Price=89.99m}
            };
            return View(products);
        }
    }
}