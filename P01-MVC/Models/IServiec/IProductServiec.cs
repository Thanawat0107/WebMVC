namespace P01_MVC.Models.IServiec
{
    public interface IProductServiec
    {
        void GenerateProduct(int number);
        List<Product> GenerateProductAll();
    }
}
