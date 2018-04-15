using ManageFleet.Domain.Entities;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Domain.Interfaces.Services;
using System;
using System.Linq;

namespace ManageFleet.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle Insert(Vehicle vehicle)
        {
            if (!vehicle.IsValid())
                return vehicle;

            var existingChassi = _vehicleRepository.Filter(p => p.Chassi.Equals(vehicle.Chassi));

            if (existingChassi.Count() == 0)
            {
                vehicle = _vehicleRepository.Insert(vehicle);
                vehicle.ValidationResult = new Validations.ValidationResult("Veiculo inserido com sucesso.");
                return vehicle;
            }

            vehicle.ValidationResult = new Validations.ValidationResult(false, "Chassi ja cadastrado no sistema.");
            return vehicle;
        }
        
        public Vehicle Update(Vehicle vehicle)
        {
            if (!vehicle.IsValid())
                return vehicle;

            var existingChassi = _vehicleRepository.Filter(p => p.Chassi.Equals(vehicle.Chassi) && !p.Id.Equals(vehicle.Id));

            if (existingChassi.Count() == 0)
            {
                vehicle = _vehicleRepository.Update(vehicle);
                vehicle.ValidationResult = new Validations.ValidationResult("Veiculo alterado com sucesso.");
                return vehicle;
            }

            vehicle.ValidationResult = new Validations.ValidationResult(false, "Chassi ja cadastrado no sistema.");
            return vehicle;
        }

        public Vehicle Remove(int id)
        {
            var vehicle = new Vehicle();
            _vehicleRepository.Remove(id);
            vehicle.ValidationResult = new Validations.ValidationResult("Veiculo removido com sucesso.");
            return vehicle;
        }

        public void Dispose()
        {
            _vehicleRepository.Dispose();
        }
    }
}