using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        }
    }
}