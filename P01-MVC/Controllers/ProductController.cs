using Microsoft.AspNetCore.Mvc;
using P01_MVC.Models.IServiec;

namespace P01_MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var ps = new ProductServiec();
            ps.GenerateProduct(20);
            return View(ps.GenerateProductAll());
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
