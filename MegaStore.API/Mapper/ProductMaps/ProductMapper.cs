using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Product;
using MegaStore.API.Models.Product.Product;

namespace MegaStore.API.Mapper.ProductMaps
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CategoryForAddDto, Category>();
            CreateMap<ProductForAddDto, Product>();

            CreateMap<Category, CategoryForListDto>();
            CreateMap<Category, CategoryForDetailsDto>();

            CreateMap<Product, ProductForListDto>();
            CreateMap<Product, ProductForDetailsDto>();

            CreateMap<ColorForAddDto, Color>();
            CreateMap<Color, ColorDto>();
            CreateMap<ProductFileForAddDto, ProductFile>();
        }
    }
}