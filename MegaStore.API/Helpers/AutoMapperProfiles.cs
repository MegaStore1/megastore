using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaStore.API.Dtos;
using MegaStore.API.Dtos.Core;
using MegaStore.API.Models;
using MegaStore.API.Models.Core;

namespace MegaStore.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });

            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                });
            CreateMap<Photo, PhotosForDetailedDto>();


            CreateMap<UserForUpdateDto, User>();

            CreateMap<Module, ModuleForListDto>();

            CreateMap<Module, ModuleForDetailDto>();

            CreateMap<ModuleForUpdateDto, Module>();
        }
    }
}