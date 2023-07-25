using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Customer;
using MegaStore.API.Models.Customer;

namespace MegaStore.API.Mapper.Customer
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<CustomerForRegisterDto, MegaStore.API.Models.Customer.Customer>();
            CreateMap<CustomerForLoginDto, MegaStore.API.Models.Customer.Customer>();
            CreateMap<MegaStore.API.Models.Customer.Customer, CustomerForDetailsDto>();
            CreateMap<CustomerToActivateDto, MegaStore.API.Models.Customer.CustomerVerificationCode>();
            CreateMap<CustomerShippingAddressForAddDto, ShippingAddress>();
            CreateMap<ShippingAddress, ShippingAddressDto>();
        }
    }
}