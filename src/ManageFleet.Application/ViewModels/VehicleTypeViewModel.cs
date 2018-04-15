using System.ComponentModel.DataAnnotations;

namespace ManageFleet.Application.ViewModels
{
    public class VehicleTypeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tipo de Veículo")]
        public string Description { get; set; }

        [Display(Name = "Quantidade de Passageiros")]
        public byte Capacity { get; set; }
    }
}