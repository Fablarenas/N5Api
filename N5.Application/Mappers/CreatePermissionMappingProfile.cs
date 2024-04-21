using AutoMapper;
using N5.Application.Commands;
using N5.Application.Dtos;
using N5.Domain.Entities;

namespace N5.Application.Mappers
{
    public class CreatePermissionMappingProfile : Profile
    {
        public CreatePermissionMappingProfile()
        {

            //Create Permission
            CreateMap<CreatePermissionDto, CreatePermissionCommand>()
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ReverseMap();

            CreateMap<CreatePermissionCommand, Permission>()
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ReverseMap();


            // Update Permission

            CreateMap<ModifyPermissionDto, ModifyPermissionCommand>()
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ReverseMap();

            CreateMap<ModifyPermissionCommand, Permission>()
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ReverseMap();
        }
    }
}
