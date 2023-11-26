using Microsoft.AspNetCore.Mvc;
using P01_MVC.Models.IServiec;

namespace P01_MVC.Controllers
{
    public class TestProductController : Controller
    {
        private readonly IProductServiec ps;
        public TestProductController(IProductServiec ps)
        {
            this.ps = ps;
        }
        public IActionResult Index()
        {
            return View( ps.GenerateProductAll());
        }

        public IActionResult Delete(int Id)
        {
            ps.DeleteProduct(Id);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

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
