using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Order;
using MegaStore.API.Models.Order;

namespace MegaStore.API.Mapper.OrderMaps
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderForAddDto, Order>();
            CreateMap<Order, OrderForListDto>()
                .ForMember(dest => dest.lineCount, opt =>
                {
                    opt.MapFrom(src => src.lines.Count());
                });
            CreateMap<Order, OrderDetailsDto>();
            CreateMap<OrderLineForAddDto, OrderLine>();
            CreateMap<OrderLine, OrderForListDto>();
            CreateMap<OrderLine, OrderLineForDetailsDto>();
        }
    }
}