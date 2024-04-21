using AutoMapper;
using N5.Domain.Entities;
using N5.Infraestructure.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Infraestructure.Mappers
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Permission, PermissionEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ForMember(dest => dest.PermissionType, opt => opt.MapFrom(src => src.PermissionType))
                .ReverseMap();

            CreateMap<PermissionType, PermissionTypeEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Permissions, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
