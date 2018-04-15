using AutoMapper;
using ManageFleet.Application.Interfaces;
using ManageFleet.Application.ViewModels;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Infra.Data.Interfaces;
using System.Collections.Generic;

namespace ManageFleet.Application.Services
{
    public class VehicleTypeAppService : AppService, IVehicleTypeAppService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleTypeAppService(IVehicleTypeRepository vehicleTypeRepository, IUnitOfWork uow) : base(uow)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public IEnumerable<VehicleTypeViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<VehicleTypeViewModel>>(_vehicleTypeRepository.GetAll());
        }

        public void Dispose()
        {
            _vehicleTypeRepository.Dispose();
        }
    }
}