using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Mapper.Core
{
    public class CoreMapper : Profile
    {
        public CoreMapper()
        {
            CreateMap<ModulePageForUpdateDto, ModulePage>();
        }
    }
}