using ManageFleet.Domain.Entities;
using System;

namespace ManageFleet.Domain.Interfaces.Services
{
    public interface IVehicleService : IDisposable
    {
        Vehicle Insert(Vehicle vehicle);

        Vehicle Update(Vehicle vehicle);

        Vehicle Remove(int id);
    }
}