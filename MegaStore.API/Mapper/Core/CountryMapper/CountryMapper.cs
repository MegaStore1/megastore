using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Core.Country;
using MegaStore.API.Models.Core.CountryModel;

namespace MegaStore.API.Mapper.Core.CountryMapper
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<Country, CountryForListDto>();
            CreateMap<Country, CountryForDetailsDto>();
            CreateMap<State, StateDto>()
                .ForMember(dest => dest.countryName, opt =>
                {
                    opt.MapFrom(src => src.country.countryName);
                });
        }
    }
}