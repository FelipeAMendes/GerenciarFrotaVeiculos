using ManageFleet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageFleet.Infra.Data.Context
{
    public class ManageFleetContext : DbContext
    {
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        public ManageFleetContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../ManageFleet.Web/ManageFleet.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityTypeBuilderVehicle = modelBuilder.Entity<Vehicle>();
            var entityTypeBuilderVehicleType = modelBuilder.Entity<VehicleType>();

            entityTypeBuilderVehicle.Ignore(p => p.ValidationResult);
            entityTypeBuilderVehicle.HasKey(p => p.Id);
            entityTypeBuilderVehicle.Property(p => p.Chassi).IsRequired().HasMaxLength(17);
            entityTypeBuilderVehicle.Property(p => p.Color).IsRequired().HasMaxLength(50);

            entityTypeBuilderVehicleType.HasKey(p => p.Id);
            entityTypeBuilderVehicleType.Property(p => p.Description).IsRequired().HasMaxLength(50);
            entityTypeBuilderVehicleType.Property(p => p.Capacity).IsRequired();

            entityTypeBuilderVehicle.HasOne(p => p.VehicleType).WithMany(p => p.Vehicles).HasForeignKey(p => p.VehicleTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}