using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController1 : Controller
    {
        public IActionResult Index()
        {
            var product = new List<Product>()
            {
                new Product() {id=1, name="Coffee1",price=100,amout=10},
                new Product() {id=2, name="Coffee2",price=200,amout=20},

            };
            return View(new {product,Title="Coffee Sho"} );
        }
    }
}
