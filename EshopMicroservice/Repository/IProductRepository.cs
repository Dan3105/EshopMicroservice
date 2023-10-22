using EshopMicroservice.Models;

namespace EshopMicroservice.Repository
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        bool Save();
    }
}
