using ManageFleet.Domain.Validations;

namespace ManageFleet.Domain.Entities
{
    public class Vehicle : Entity
    {
        public string Chassi { get; set; }
        public string Color { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Vehicle()
        {
            ValidationResult = new ValidationResult();
        }

        public Vehicle(string chassi, string color, int vehicleTypeId)
        {
            AssertionConcern.AssertArgumentNotNull(chassi, "Chassi do veículo não pode ser nulo.");
            AssertionConcern.AssertArgumentLength(chassi, 17, 17, "Chassi deve ter 17 caracteres.");
            AssertionConcern.AssertArgumentNotNull(color, "Cor do veículo não pode ser nula.");
            AssertionConcern.AssertArgumentLength(color, 2, 50, "Cor do veículo deve ter entre 2 e 50 caracteres.");
            AssertionConcern.AssertArgumentGreaterThanZero(vehicleTypeId, "Tipo do veículo não pode ser vazio.");

            this.Chassi = chassi;
            this.Color = color;
            this.VehicleTypeId = vehicleTypeId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}