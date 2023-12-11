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

        [HttpPost] //กด submit ให้มาที่นี้
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //กด submit ให้มาที่นี้
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View();
            ps.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = ps.GetById(id);
            if (product == null)
            {
                TempData["Narney"] = true; //นำไปใช้ที่หน้า View
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return View();
            ps.Update(product);
            return RedirectToAction("Index");
        }
    }
}
