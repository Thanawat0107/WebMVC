using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using P05_UploadFile.Data;
using P05_UploadFile.Settings;

namespace P05_UploadFile.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext dataContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductService(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dataContext = dataContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task Add(Product product, IFormFile file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);

                var folers = Path.Combine(wwwRootPath, Paths.Images);  //ต่อไฟล์โดยใส่เครื่องหมาย \ ให้ด้วย

                var externaiFile = Path.Combine(folers, fileName + extension); //png, jpg ตัวไฟล์จริงๆ
                var fileInDatabase = fileName + extension; //มีแค่ชื่อ


                if (!Directory.Exists(folers)) Directory.CreateDirectory(folers);

                using (var fileStreams = new FileStream(externaiFile, FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                product.Image = fileInDatabase;

            }
            await dataContext.Products.AddAsync(product);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            if (!string.IsNullOrEmpty(product.Image))
            {
                var fileDelete = webHostEnvironment.WebRootPath + product.Image;
                if (File.Exists(fileDelete)) File.Delete(fileDelete);
            }

            dataContext.Products.Remove(product);
            await dataContext.SaveChangesAsync();
        }

        public async Task<Product> Find(int id)
        {
            var product = await dataContext.Products.FindAsync(id);
            if (!string.IsNullOrEmpty(product.Image))
            {
                product.Image = Path.Combine("\\", Paths.Images, product.Image);
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var product = await dataContext.Products.ToListAsync();

            product.ForEach(p =>
            {
                p.Image = !String.IsNullOrEmpty(p.Image) ? Path.Combine(
                    Paths.Images, p.Image) : "no_Image.jpg";
            });

            return product;
        }

        public async Task Update(Product product, IFormFile file)
        {
            string wwwRootPath = webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);

                var folers = Path.Combine(wwwRootPath, Paths.Images);  //ต่อไฟล์โดยใส่เครื่องหมาย \ ให้ด้วย

                var externaiFile = Path.Combine(folers, fileName + extension); //png, jpg ตัวไฟล์จริงๆ
                var fileInDatabase = fileName + extension; //มีแค่ชื่อ


                if (!Directory.Exists(folers)) Directory.CreateDirectory(folers);

                //สร้างไฟล์ใหม่
                using (var fileStreams = new FileStream(externaiFile, FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }

                //ลบไฟล์เดิม

                if (!string.IsNullOrEmpty(product.Image))
                {
                    var fileDelete = webHostEnvironment.WebRootPath + product.Image;
                    if (File.Exists(fileDelete)) File.Delete(fileDelete);
                }



                product.Image = fileInDatabase;

            }

            dataContext.Products.Update(product);
            await dataContext.SaveChangesAsync();

        }
    }
}
