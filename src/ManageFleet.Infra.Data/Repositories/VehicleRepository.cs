using System.Collections.Generic;
using ManageFleet.Domain.Entities;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Infra.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ManageFleet.Infra.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ManageFleetContext context)
            : base(context)
        {

        }

        public override Vehicle GetById(int id)
        {
            return _context.Vehicles
                .Include(p => p.VehicleType)
                .FirstOrDefault(p => p.Id.Equals(id));
        }

        public override IEnumerable<Vehicle> GetAll()
        {
            var query =
                from vehicle in _context.Vehicles
                join vehicleType in _context.VehicleTypes
                on vehicle.VehicleTypeId equals vehicleType.Id
                select new Vehicle
                {
                    Id = vehicle.Id,
                    Chassi = vehicle.Chassi,
                    Color = vehicle.Color,
                    VehicleTypeId = vehicle.VehicleTypeId,
                    VehicleType = new VehicleType
                    {
                        Id = vehicleType.Id,
                        Description = vehicleType.Description,
                        Capacity = vehicleType.Capacity
                    }
                };

            return query.ToList();
        }

        public override IEnumerable<Vehicle> Filter(Expression<Func<Vehicle, bool>> predicate)
        {
            return _context.Vehicles
                .Include(p => p.VehicleType)
                .Where(predicate);
        }
    }
}