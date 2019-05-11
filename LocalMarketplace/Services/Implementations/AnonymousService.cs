using LocalMarketplace.Models.DatabaseModels;
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
        private readonly ProductContext productContext;

        public AnonymousService(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public List<Product> GetAllProducts()
        {
            return productContext.Products.OrderByDescending(o=>o.Id).Take(5).ToList();
        }

        public List<Product> SearchProducts(string search)
        {
            return productContext.Products.Where(s => s.Name.Contains(search)).ToList();
        }


    }
}
