using EshopMicroservice.DBContext;
using EshopMicroservice.Models;

namespace EshopMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public void CreateProduct(Product product)
        {
            _context.Add<Product>(product);
            Save();
        }

        public void DeleteProduct(int id)
        {
            var product = GetProduct(id);
            _context.Remove<Product>(product);
            Save(); 
        }

        public Product GetProduct(int id)
        {
            return _context.Products?.Find(id);
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool Save()
        {
           return _context.SaveChanges() > 0;
        }

        public void UpdateProduct(Product product)
        {
            _context.Update<Product>(product); Save();
        }
    }
}
