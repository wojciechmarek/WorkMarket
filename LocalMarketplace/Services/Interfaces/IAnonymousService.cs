using LocalMarketplace.Models.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalMarketplace.Services.Interfaces
{
    public interface IAnonymousService
    {
        List<Product> GetAllProducts();
        List<Product> SearchProducts(string search);
    }
}
