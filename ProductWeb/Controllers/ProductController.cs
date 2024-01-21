using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductWeb.ViewModels;

namespace ProductWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _ps;

        public ProductController(ProductContext ps)
        {
            _ps = ps;
        }

        public IActionResult Index()
        {
            var product = _ps.Products.Include(p=>p.Category).ToList();
            return View(product);
        }

        public IActionResult CreateOfUpdate(int? id)
        {
            var productVM = new ProductVM()
            {
                Product = new(),
                CategoryList = _ps.Categories.Select(item => new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                })
            }; 
            if (id != null && id != 0)
            {
                //update
                productVM.Product = _ps.Products.Find(id);

                if (productVM.Product == null) return RedirectToAction(nameof(Index));
            }

            return View(productVM);
        }

        [HttpPost]
        public IActionResult CreateOfUpdate(ProductVM productVM)
        {
            var id = productVM.Product.Id;
            if (id != 0)
            {
                //update
                _ps.Update(productVM.Product.Id);

            }
            else
            {
                //create
                _ps.Add(productVM.Product);

            }
            _ps.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) {
            var product = _ps.Products.Find(id);

            if (product == null)
            {
                TempData["success"] = "ลบเรียบร้อยหายไปแล้วว";
                return RedirectToAction(nameof(Index));
            }

            _ps.Remove(product);
            _ps.SaveChanges();
            TempData["success"] = "ลบเรียบร้อยหายไปแล้วว";
            return RedirectToAction(nameof(Index));
        }
    }
}
