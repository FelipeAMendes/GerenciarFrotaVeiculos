using ManageFleet.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ManageFleet.Application.Interfaces
{
    public interface IVehicleAppService : IDisposable
    {
        VehicleListViewModel GetById(int id);

        VehicleViewModel GetByIdRegister(int id);

        VehicleListViewModel GetByChassi(string searchChassi);

        IEnumerable<VehicleListViewModel> GetAll();

        VehicleViewModel Insert(VehicleViewModel obj);

        VehicleViewModel Update(VehicleViewModel obj);

        VehicleViewModel Remove(int id);
    }
}