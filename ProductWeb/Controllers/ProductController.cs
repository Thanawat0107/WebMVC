using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductWeb.Data;
using ProductWeb.ViewModels;

namespace ProductWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _ps;
        private readonly IWebHostEnvironment _ws;

        public ProductController(ProductContext ps, IWebHostEnvironment ws)
        {
            _ps = ps;
            _ws = ws;
        }

        public IActionResult Index()
        {
            var product = _ps.Products.Include(p=>p.Category).ToList();

            foreach (var item in product)
            {
                if (!string.IsNullOrEmpty(item.ImageUrl))
                {
                    item.ImageUrl = SD.ProductPath + "\\" + item.ImageUrl;
                }
            }
            return View(product);
        }

        public IActionResult CreateOfUpdate(int? id)
        {
            var productVM = new ProductVM()
            {
                Product = new()
                { 
                    Name = "test",
                    Description = "test",
                    Price = 1,
                },
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
            if (!ModelState.IsValid) return View(productVM);

            #region การจัดการรูปภาพ
            string wwwRootPath = _ws.WebRootPath;
            var file = productVM.file;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);
                var uploads = wwwRootPath + SD.ProductPath; //wwwroot\images\product

                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                //กรณีมีรูปภาพเดิมตอ้งลบทิ้งก่อน
                if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                {
                    //wwwroot\images\product\test.jpg;
                    var oldImagePath = Path.Combine(uploads,productVM.Product.ImageUrl);

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                //บันทึกรุปภาพใหม่
                using (var fileStreams = new FileStream(Path.Combine(uploads,fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                productVM.Product.ImageUrl = fileName + extension;
            }
            #endregion การจัดการรูปภาพ

            var id = productVM.Product.Id;
            if (id != 0)
            {
                //update
                _ps.Update(productVM.Product);

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

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                var oldImagePath = _ws.WebRootPath + SD.ProductPath + "\\" + product.ImageUrl;
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _ps.Remove(product);
            _ps.SaveChanges();
            TempData["success"] = "ลบเรียบร้อยหายไปแล้วว";
            return RedirectToAction(nameof(Index));
        }
    }
}
