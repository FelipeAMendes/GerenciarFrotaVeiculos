using AutoMapper;
using ManageFleet.Application.Interfaces;
using ManageFleet.Application.ViewModels;
using ManageFleet.Domain.Entities;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Domain.Interfaces.Services;
using ManageFleet.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ManageFleet.Application.Services
{
    public class VehicleAppService : AppService, IVehicleAppService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;

        public VehicleAppService(IVehicleRepository vehicleRepository, IVehicleService vehicleService, IMapper mapper, IUnitOfWork uow) : base(uow)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleService = vehicleService;
            _mapper = mapper;
        }
        
        public VehicleListViewModel GetById(int id)
        {
            return _mapper.Map<VehicleListViewModel>(_vehicleRepository.GetById(id));
        }

        public VehicleViewModel GetByIdRegister(int id)
        {
            return _mapper.Map<VehicleViewModel>(_vehicleRepository.GetById(id));
        }

        public VehicleListViewModel GetByChassi(string searchChassi)
        {
            Expression<Func<Vehicle, bool>> predicate = (p) => p.Chassi.Equals(searchChassi);

            return _mapper.Map<VehicleListViewModel>(_vehicleRepository.Filter(predicate).FirstOrDefault());
        }

        public IEnumerable<VehicleListViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<VehicleListViewModel>>(_vehicleRepository.GetAll());
        }
        
        public VehicleViewModel Insert(VehicleViewModel obj)
        {
            BeginTransaction();
            var activityAdded = _vehicleService.Insert(_mapper.Map<Vehicle>(obj));
            Commit();
            return _mapper.Map<VehicleViewModel>(activityAdded);
        }
        
        public VehicleViewModel Update(VehicleViewModel obj)
        {
            BeginTransaction();
            var activityUpdated = _vehicleService.Update(_mapper.Map<Vehicle>(obj));
            Commit();

            return _mapper.Map<VehicleViewModel>(activityUpdated);
        }
        
        public VehicleViewModel Remove(int id)
        {
            BeginTransaction();
            var activityRemoved = _vehicleService.Remove(id);
            Commit();

            return _mapper.Map<VehicleViewModel>(activityRemoved);
        }
        
        public void Dispose()
        {
            _vehicleRepository.Dispose();
        }
    }
}