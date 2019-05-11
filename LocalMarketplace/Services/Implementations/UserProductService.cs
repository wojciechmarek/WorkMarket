using LocalMarketplace.Models.DatabaseModels;
using LocalMarketplace.Models.DTOs;
using LocalMarketplace.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

namespace LocalMarketplace.Services.Implementations
{
    public class UserProductService : IUserProductService
    {
        private readonly ProductContext productContext;

        public UserProductService(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        public void AddProduct(Product product, string userId)
        {
            Product productToAdd = new Product()
            {
                UserId = userId,
                Name = product.Name,
                Description = product.Description,
                Pictures = product.Pictures,
            };

            productContext.Products.Add(productToAdd);
            productContext.SaveChanges();
        }

        public List<Product> GetAllProducts(string userId)
        {
            return productContext.Products
                .Include(p=>p.Pictures)
                .Where(p => p.UserId.Equals(userId))
                .ToList();
        }

        public Product GetProductById(int productId, string userId)
        {
            return productContext.Products
                .Include(p => p.Pictures)
                .Where(p => p.UserId.Equals(userId))
                .Where(p => p.Id == productId)
                .SingleOrDefault();
        }

        public void RemoveProduct(int productId, string userId)
        {
            Product product = GetProductById(productId, userId);
            if (product == null)
                return;

            productContext.Products.Remove(product);
            productContext.SaveChanges();

        }

        public void UpdateProduct(Product product, string userId)
        {
            Product productToUpdate = GetProductById(product.Id, userId);
            if (product == null)
                return;

            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Pictures = product.Pictures;

            productContext.Products.Update(productToUpdate);
            productContext.SaveChanges();
        }
    }
}
