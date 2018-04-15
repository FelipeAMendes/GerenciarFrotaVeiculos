using AutoMapper;
using ManageFleet.Application.ViewModels;
using ManageFleet.Domain.Entities;

namespace ManageFleet.Application.AutoMapper
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>()
                .ReverseMap()
                .ForMember(p => p.VehicleType, opt => opt.Ignore());
            CreateMap<Vehicle, VehicleListViewModel>()
                .ForMember(p => p.NomeTipoVeiculo, opt => opt.MapFrom(src => src.VehicleType.Description))
                .ForMember(p => p.QuantidadePassageiros, opt => opt.MapFrom(src => src.VehicleType.Capacity.ToString()));
            CreateMap<VehicleType, VehicleTypeViewModel>()
                .ReverseMap()
                .ForMember(p => p.Vehicles, opt => opt.Ignore());

            //Mapper.Configuration.AssertConfigurationIsValid()
        }
    }
}