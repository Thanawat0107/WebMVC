using Microsoft.AspNetCore.Mvc;
using P03_CodeFirst.Models;
using P03_CodeFirst.Services;

namespace P03_CodeFirst.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices ps;
        public ProductController(IProductServices ps) 
        {
            this.ps = ps;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> Product = ps.GetAll();
            return View(Product);
        }

        public IActionResult Delete(int id)
        {
            var product = ps.GetById(id);

            if (product == null)
            {
                TempData["Narney"] = true; //นำไปใช้ที่หน้า View
            }
            else
            {
                ps.Delete(product);
            }
            return RedirectToAction("Index");
        }
    }
}
