using ManageFleet.Application.Interfaces;
using ManageFleet.Application.Services;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Domain.Interfaces.Services;
using ManageFleet.Domain.Services;
using ManageFleet.Infra.Data.Context;
using ManageFleet.Infra.Data.Interfaces;
using ManageFleet.Infra.Data.Repositories;
using ManageFleet.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace ManageFleet.Infra.IoC
{
    public static class BootStrapper
    {
        public static IServiceCollection AddServicesManageFleet(this IServiceCollection services)
        {
            return services
                .AddDbContext<ManageFleetContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                // Application
                .AddScoped<IVehicleAppService, VehicleAppService>()
                .AddScoped<IVehicleTypeAppService, VehicleTypeAppService>()
                // Repository
                .AddScoped<IVehicleRepository, VehicleRepository>()
                .AddScoped<IVehicleTypeRepository, VehicleTypeRepository>()
                // Service
                .AddScoped<IVehicleService, VehicleService>();
        }
    }
}