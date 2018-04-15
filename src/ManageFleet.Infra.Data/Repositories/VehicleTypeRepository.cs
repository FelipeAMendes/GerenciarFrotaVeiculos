using ManageFleet.Domain.Entities;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Infra.Data.Context;

namespace ManageFleet.Infra.Data.Repositories
{
    public class VehicleTypeRepository : Repository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(ManageFleetContext context)
            : base(context)
        { }
    }
}