using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Dtos.Core.Shared;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Mapper.Core.Shared
{
    public class SharedMapper : Profile
    {
        public SharedMapper()
        {
            CreateMap<ModulePage, ModulePageDto>();
            CreateMap<BaseDto, Base>();
            CreateMap<Base, BaseDto>();
        }
    }
}