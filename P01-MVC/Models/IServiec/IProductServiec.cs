namespace P01_MVC.Models.IServiec
{
    public interface IProductServiec
    {
        void GenerateProduct(int number);
        List<Product> GenerateProductAll();
        Product SearchProduct(int Id);
        void AddProduct(Product product);
        void DeleteProduct(int Id);
        void UpdateProduct(Product product);
    }
}
