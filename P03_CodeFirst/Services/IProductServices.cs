using P03_CodeFirst.Models;

namespace P03_CodeFirst.Services
{
    public interface IProductServices
    {
        void GenerateProduct(int number);
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Delete(Product product);
        
    }
}
