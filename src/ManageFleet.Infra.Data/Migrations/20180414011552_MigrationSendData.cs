using ManageFleet.Domain.Entities;
using ManageFleet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.ObjectModel;
using System.Linq;

namespace ManageFleet.Infra.Data.Migrations
{
    public partial class MigrationSendData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var db = new ManageFleetContext())
            {
                var vehiclesTypes = new Collection<VehicleType>
                {
                    new VehicleType("Caminhão", 2),
                    new VehicleType("Ônibus", 42)
                };

                db.VehicleTypes.AddRange(vehiclesTypes);
                db.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            using (var db = new ManageFleetContext())
            {
                db.VehicleTypes.RemoveRange(db.VehicleTypes.AsQueryable());
                db.SaveChanges();
            }
        }
    }
}