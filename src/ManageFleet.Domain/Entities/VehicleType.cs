using ManageFleet.Domain.Validations;
using System.Collections.Generic;

namespace ManageFleet.Domain.Entities
{
    public class VehicleType : Entity
    {
        public string Description { get; set; }
        public byte Capacity { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public VehicleType()
        {

        }

        public VehicleType(string description, byte capacity)
        {
            AssertionConcern.AssertArgumentNotNull(description, "Descrição do tipo do veículo não pode ser nula.");
            AssertionConcern.AssertArgumentLength(description, 2, 50, "Descrição do tipo do veículo deve ter entre 2 e 50 caracteres.");
            AssertionConcern.AssertArgumentGreaterThanZero(capacity, "Capacidade do tipo do veículo deve ser maior que zero.");

            this.Description = description;
            this.Capacity = capacity;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}