using P03_CodeFirst.Data;
using P03_CodeFirst.Models;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P03_CodeFirst.Services
{
    public class ProductServices : IProductServices
    {
        private readonly DataContext _db;

        List<Product> ProductList;
        public ProductServices(DataContext _db) 
        {
            this._db = _db;
            ProductList = new List<Product>();
            //GenerateProduct();
            if (_db.Products.Count() == 0 ) GenerateProduct();
        }

        public void Delete(Product product)
        {
            _db.Products.Remove(product); //memory
            _db.SaveChanges(); // ลบจริง
        }

        public void GenerateProduct(int number=10)
        {
            Random random = new Random();
           for (int i = 1; i <= number; i++)
            {
                ProductList.Add(new Product
                {
                    //Id = i,
                    Name = "Coffee",
                    Price = random.Next(10, 100),
                    Amount = random.Next(1, 10),
                });
            }
            _db.Products.AddRange(ProductList); //Memoey
            _db.SaveChanges(); //Write to Hardisk
        }

        public IEnumerable<Product> GetAll()
        {
            var test= _db.Products.ToList();
            return _db.Products.ToList();
        }

        public Product GetById(int id)
        {
            var product = _db.Products.Find(id);

            return product;
        }
    }
}
