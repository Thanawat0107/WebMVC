using P01_MVC.Models.Settings;

namespace P01_MVC.Models.IServiec
{
    public class ProductServiec : IProductServiec
    {
        public List<Product> ProductList { get; set;}

        public ProductServiec()
        {
            ProductList= new List<Product>();
        }

        public void GenerateProduct(int number=10)
        {
           Random rand = new Random();
            var numberOfName = NameOfProduct.ProductName.Count;
           for (int i = 1; i < number; i++)
            {
                ProductList.Add(new Product
                {
                    id = i,
                    name = NameOfProduct.ProductName[rand.Next(numberOfName)],
                    price = rand.Next(200) + 10,
                    amout = rand.Next(100) +1
                });
            }
        }

        public List<Product> GenerateProductAll()
        {
            var ps = new ProductServiec();
            ps.GenerateProduct();
            return ProductList;
        }

        public Product SearchProduct(int Id)
        {
            return ProductList.Find(x => x.id== Id);
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }
    }
}
