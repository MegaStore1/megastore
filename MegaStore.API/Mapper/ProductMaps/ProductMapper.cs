using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Product;
using MegaStore.API.Models.Product.Inventory;
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

            CreateMap<Product, ProductForListDto>()
                .ForMember(dest => dest.total, opt =>
                {
                    opt.MapFrom(src => src.lines.Sum(o => o.amount) - src.lines.Sum(o => o.orderLines.Sum(o => o.amount)));
                })
                .ForMember(dest => dest.lineId, opt =>
                {
                    opt.MapFrom(src => src.lines
                    .FirstOrDefault(o => o.orderLines.Sum(o => o.amount) < o.amount).id);
                })
                .ForMember(dest => dest.totalAvailable, opt =>
                {
                    opt.MapFrom(src => src.lines
                    .FirstOrDefault(o => o.orderLines.Sum(o => o.amount) < o.amount).amount - src.lines
                    .FirstOrDefault(o => o.orderLines.Sum(o => o.amount) < o.amount).orderLines.Sum(o => o.amount)
                    );
                });
            CreateMap<Product, ProductForDetailsDto>()
                .ForMember(dest => dest.total, opt =>
                {
                    opt.MapFrom(src => src.lines.Sum(o => o.amount) - src.lines.Sum(o => o.orderLines.Sum(o => o.amount)));
                })
                .ForMember(dest => dest.lineId, opt =>
                {
                    opt.MapFrom(src => src.lines
                    .FirstOrDefault(o => o.orderLines.Sum(o => o.amount) < o.amount).id);
                })
                .ForMember(dest => dest.totalAvailable, opt =>
                {
                    opt.MapFrom(src => src.lines
                    .FirstOrDefault(o => o.orderLines.Sum(o => o.amount) < o.amount).amount - src.lines
                    .FirstOrDefault(o => o.orderLines.Sum(o => o.amount) < o.amount).orderLines.Sum(o => o.amount)
                    );
                });

            CreateMap<ColorForAddDto, Color>();
            CreateMap<Color, ColorDto>();
            CreateMap<ProductFileForAddDto, ProductFile>();
            CreateMap<ProductFile, ProductFileForListDto>();

            CreateMap<ProductLine, ProductLineDto>();
            CreateMap<ProductLine, ProductLineForDetailsDto>()
                .ForMember(dest => dest.available, opt =>
                {
                    opt.MapFrom(src => src.amount - src.orderLines.Sum(o => o.amount));
                });
            CreateMap<ProductLineToCreateDto, ProductLine>();
        }
    }
}