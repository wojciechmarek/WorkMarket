using LocalMarketplace.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Services.Interfaces
{
    public interface IUserProductService
    {
        Task<List<ProductGet>> GetAllProductsAsync();
        Task<ProductGet> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductAdd product);
        Task UpdateProductAsync(ProductAdd product);
        Task RemoveProductAsync(int id);
    }
}
