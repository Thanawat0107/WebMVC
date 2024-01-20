using Microsoft.AspNetCore.Mvc;

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
    }
}
