using Microsoft.AspNetCore.Mvc;
using P01_MVC.Models;
using P01_MVC.Models.IServiec;

namespace P01_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiec ps;
        // เรียกใช้ DI
        public ProductController(IProductServiec ps) 
        {
            this.ps = ps;
        }

        public IActionResult Index()
        {
            return View(ps.GenerateProductAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        //ปลายทาง
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) { return View(); }
            var result = ps.SearchProduct(product.id);
            if (result == null)
            {
                ps.AddProduct(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            ps.DeleteProduct(Id);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var result = ps.SearchProduct(Id);

            if (result == null) return RedirectToAction("Index");

            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) { return View(); }

            ps.UpdateProduct(product);

            return RedirectToAction("Index");
        }
    }
}
