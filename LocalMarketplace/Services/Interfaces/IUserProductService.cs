using LocalMarketplace.Models.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalMarketplace.Services.Interfaces
{
    public interface IUserProductService
    {
        List<Product> GetAllProducts(string userId);
        Product GetProductById(int productId, string userId);
        void AddProduct(Product product, string userId);
        void UpdateProduct(Product product, string userId);
        void RemoveProduct(int id, string userId);
    }
}
