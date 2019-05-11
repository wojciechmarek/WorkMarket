using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocalMarketplace.Models;
using Microsoft.AspNetCore.Identity;
using LocalMarketplace.Models.DTOs;
using LocalMarketplace.Services.Interfaces;
using System.Collections.ObjectModel;

namespace LocalMarketplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnonymousService anonymousService;

        private readonly string userId;

        public HomeController(IAnonymousService anonymousService)
        {
            this.anonymousService = anonymousService;
        }

        ////////////////// PUBLIC METHODS //////////////////

        // INDEX - GET
        public IActionResult Index()
        {
            var last5products = anonymousService.GetAllProducts();

            if (last5products == null)
                return View(new List<ProductResponse>());
            else
            {
                List<ProductResponse> last5productsList = new List<ProductResponse>();

                foreach (var product in last5products)
                {
                    last5productsList.Add(new ProductResponse()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Pictures = PictureCollectionToList(product),
                    });
                }

                return View(last5productsList);
            }
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(string productToSearch)
        {
            if (ModelState.IsValid)
            {
                var searchedProducts = anonymousService.SearchProducts(productToSearch);

                List<ProductResponse> searchedProductsList = new List<ProductResponse>();

                foreach (var product in searchedProducts)
                {
                    searchedProductsList.Add(new ProductResponse()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Pictures = PictureCollectionToList(product),
                    });
                }

                return View(searchedProductsList);
            }
            return RedirectToAction(nameof(Index));
           
        }

        // HELPERS
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


    }
}
