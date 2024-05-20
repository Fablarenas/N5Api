using AutoMapper;
using N5.Application.Commands;
using N5.Application.Dtos;
using N5.Application.Queries;
using N5.Domain.Entities;

namespace N5.Application.Mappers
{
    public class CreatePermissionMappingProfile : Profile
    {
        public CreatePermissionMappingProfile()
        {

            //Create Permissionf
            CreateMap<GetPermissionsDto, Permission>()
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.Ignore())
                .ForMember(dest => dest.PermissionType, opt => opt.MapFrom(src => src.PermissionType))
                .ReverseMap();

            CreateMap<GetPermissionsType, PermissionType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();

            //Create Permission
            CreateMap<CreatePermissionDto, CreatePermissionCommand>()
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))

                .ReverseMap();

            CreateMap<CreatePermissionCommand, Permission>()
                .ForMember(dest => dest.EmployeeForename, opt => opt.MapFrom(src => src.EmployeeForename))
                .ForMember(dest => dest.EmployeeSurname, opt => opt.MapFrom(src => src.EmployeeSurname))
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate))
                .ReverseMap();

            CreateMap<PermissionType, CreatePermissionCommand>()
                .ForMember(dest => dest.PermissionTypeDescription, opt => opt.MapFrom(src => src.Description))
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


            CreateMap<GetPermissionTypeByIdQuery, CreatePermissionDto>()
                .ForMember(dest => dest.PermissionTypeId, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ReverseMap();


            CreateMap<Permission, PermissionType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PermissionTypeId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.PermissionType.Description))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.PermissionType.Description))
                .ReverseMap();
        }
    }
}
