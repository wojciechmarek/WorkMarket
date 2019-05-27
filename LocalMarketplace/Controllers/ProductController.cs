using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocalMarketplace.Models.DatabaseModels;
using LocalMarketplace.Models.DTOs;
using LocalMarketplace.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalMarketplace.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserProductService userProductService;

        public ProductController(UserManager<IdentityUser> userManager, IUserProductService userProductService)
        {
            this.userManager = userManager;
            this.userProductService = userProductService;
        }

        // HELPERS 
        private ICollection<Models.DatabaseModels.Picture> PictureListToCollection(Models.DTOs.ProductRequest product)
        {
            ICollection<Models.DatabaseModels.Picture> pictures = new Collection<Models.DatabaseModels.Picture>();
            if (product.Pictures != null)
            {
                foreach (var pictureUrl in product?.Pictures)
                {
                    pictures.Add(new Models.DatabaseModels.Picture() { Url = pictureUrl.Url });
                }
            }

            return pictures;
        }

        private IList<Models.DTOs.Picture> PictureCollectionToList(Models.DatabaseModels.Product product)
        {
            IList<Models.DTOs.Picture> pictures = new List<Models.DTOs.Picture>();

            if (product.Pictures != null)
            {
                foreach (var pictureUrl in product.Pictures)
                {
                    pictures.Add(new Models.DTOs.Picture() { Url = pictureUrl.Url });
                }
            }

            return pictures;
        }

        private string GetCurrentUserId() => userManager.GetUserId(HttpContext.User);

        ////////////////// PUBLIC METHODS //////////////////

        // INDEX - GET
        public IActionResult Index()
        {
            var userProducts = userProductService.GetAllProducts(GetCurrentUserId());

            if (userProducts == null)
                return View(new List<ProductResponse>());
            else
            {
                List<ProductResponse> productList = new List<ProductResponse>();

                foreach (var product in userProducts)
                {
                    productList.Add(new ProductResponse()
                    {
                        Id = product.Id,
                        Title = product.Title,
                        Category = product.Category,
                        Contact = product.Contact,
                        Payment = product.Payment,
                        WorkLength = product.WorkLength,
                        WorkType = product.WorkType,
                        Description = product.Description,
                        Pictures = PictureCollectionToList(product),
                    });
                }

                return View(productList);
            }
        }

        // ADD - GET
        public IActionResult Add()
        {
            return View();
        }

        // ADD - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductRequest product)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Category = product.Category,
                    Contact = product.Contact,
                    Payment = product.Payment,
                    WorkLength = product.WorkLength,
                    WorkType = product.WorkType,
                    Description = product.Description,
                    Pictures = PictureListToCollection(product),
                };

                userProductService.AddProduct(newProduct, GetCurrentUserId());
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // DELETE - GET
        public IActionResult Delete(int? id)
        {
            int productId;

            if (id == null)
                return NotFound();
            else
                productId = (int)id;

            var productToDelete = userProductService.GetProductById(productId, GetCurrentUserId());

            if (productToDelete == null)
                return NotFound();

            return View(productToDelete);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productToDelete = userProductService.GetProductById(id, GetCurrentUserId());
            userProductService.RemoveProduct(id, GetCurrentUserId());
            return RedirectToAction(nameof(Index));
        }

        // RESPONSE - GET
        public IActionResult Details(int? id)
        {
            int productId;

            if (id == null)
                return RedirectToAction(nameof(Index));
            else
                productId = (int)id;

            var userProductById = userProductService.GetProductById(productId, GetCurrentUserId());

            if (userProductById == null)
                return RedirectToAction(nameof(Index));
            else
            {
                ProductResponse product = new ProductResponse()
                {
                    Id = userProductById.Id,
                    Title = userProductById.Title,
                    Category = userProductById.Category,
                    Contact = userProductById.Contact,
                    WorkType = userProductById.WorkType,
                    Payment = userProductById.Payment,
                    WorkLength = userProductById.WorkLength,
                    Pictures = PictureCollectionToList(userProductById),
                };

                return View(product);
            }
        }

        // EDIT - GET
        public IActionResult Edit(int? id)
        {
            int productId;

            if (id == null)
                return RedirectToAction(nameof(Index));
            else
                productId = (int)id;

            var userProductById = userProductService.GetProductById(productId, GetCurrentUserId());

            if (userProductById == null)
                return RedirectToAction(nameof(Index));
            else
            {
                ProductRequest product = new ProductRequest()
                {
                    Id = userProductById.Id,
                    Title = userProductById.Title,
                    Category = userProductById.Category,
                    Contact = userProductById.Contact,
                    WorkType = userProductById.WorkType,
                    Payment = userProductById.Payment,
                    WorkLength = userProductById.WorkLength,
                    Pictures = PictureCollectionToList(userProductById),
                };

                return View(product);
            }

            
        }

        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductRequest product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                Product editProduct = new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    Category = product.Category,
                    Contact = product.Contact,
                    Payment = product.Payment,
                    WorkLength = product.WorkLength,
                    WorkType = product.WorkType,
                    Description = product.Description,
                    Pictures = PictureListToCollection(product),
                };

                userProductService.UpdateProduct(editProduct, GetCurrentUserId());
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}