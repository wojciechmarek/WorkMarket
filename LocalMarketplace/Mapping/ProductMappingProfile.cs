using AutoMapper;
using LocalMarketplace.Models.DatabaseModels;
using LocalMarketplace.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalMarketplace.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductRequest>();
            CreateMap<ProductRequest, Product>();

            CreateMap<Product, ProductResponse>();
            CreateMap<ProductResponse, Product>();
        }
    }
}
