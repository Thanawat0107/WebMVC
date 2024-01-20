using Microsoft.AspNetCore.Mvc;

namespace ProductWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProductContext _cs;
        public CategoryController(ProductContext cs)
        {
            _cs = cs;
        }

        public IActionResult Index()
        {
            var result = _cs.Categories.ToList();
            return View(result);
        }

        public IActionResult CreateAndEdit(int? id)
        {
            var category = new Category();
            if (id == null || id == 0)
            {
                //Create
            }
            else
            {
                //Edit
                category = _cs.Categories.Find(id);
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult CreateAndEdit(Category category)
        {
            var id = category.Id;
            if (id == 0)
            {
                //Create
                _cs.Categories.Add(category);
                TempData["success"] = "สร้างให้เรียบร้อย";
            }
            else
            {
                //Edit
                _cs.Categories.Update(category);
                TempData["success"] = "แก้ไขเรียบร้อย";
            }
            _cs.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete (int id)
        {
            var category = _cs.Categories.Find(id);

            if (category != null) _cs.Categories.Remove(category);
            _cs.SaveChanges();
            TempData["success"] = "ลบเรียบร้อยหายไปปล้วว";
            return RedirectToAction(nameof(Index));
        }
    }
}
