using LocalMarketplace.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Services.Interfaces
{
    public interface IAnonymousService
    {
        Task<List<ProductGet>> GetAllProductsAsync();
        Task<List<ProductGet>> SearchProductsAsync(string search);
    }
}
