using P01_MVC.Models.Settings;

namespace P01_MVC.Models.IServiec
{
    public class ProductServiec : IProductServiec
    {
        public List<Product> ProductList { get; set;}

        public ProductServiec()
        {
            ProductList= new List<Product>();
            GenerateProduct(20);
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

        public void DeleteProduct(int Id)
        {
            var result = SearchProduct(Id);

            if (result != null) { ProductList.Remove(result); }
        }

        public void UpdateProduct(Product product)
        {
            var oldProduct = ProductList.Find(p=>p.id == product.id);
            var index = ProductList.IndexOf(oldProduct);
            if (index != -1)
            {
                ProductList.RemoveAt(index);
                ProductList.Insert(index, product);
            }
        }
    }
}

