using LocalMarketplace.Models.DTOs;
using LocalMarketplace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Services.Implementations
{
    public class AnonymousService : IAnonymousService
    {
        public Task<List<ProductGet>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductGet>> SearchProductsAsync(string search)
        {
            throw new NotImplementedException();
        }
    }
}
