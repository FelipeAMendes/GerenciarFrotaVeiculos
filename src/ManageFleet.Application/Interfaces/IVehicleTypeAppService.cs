using ManageFleet.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace ManageFleet.Application.Interfaces
{
    public interface IVehicleTypeAppService : IDisposable
    {
        IEnumerable<VehicleTypeViewModel> GetAll();
    }
}