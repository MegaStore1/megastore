using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Core.Shared;
using MegaStore.API.Dtos.Settings.Company;
using MegaStore.API.Models.Settings.Company;

namespace MegaStore.API.Mapper.Settings.CompanyMaps
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<CompanyForRegisterDto, Company>();
            CreateMap<PlantForRegisterDto, Plant>();

            CreateMap<Company, CompanyForListDto>();
            CreateMap<Company, CompanyForDetailedDto>();

            CreateMap<Plant, PlantForListDto>();
            CreateMap<Plant, PlantForDetailsDto>();

            CreateMap<SinglePlantForRegisterDto, Plant>();
            CreateMap<StatusDto, Plant>();
        }
    }
}