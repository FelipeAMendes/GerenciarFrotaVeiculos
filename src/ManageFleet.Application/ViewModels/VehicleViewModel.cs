using System.ComponentModel.DataAnnotations;

namespace ManageFleet.Application.ViewModels
{
    public class VehicleViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Chassi")]
        [Required(ErrorMessage = "Chassi do veículo é obrigatório")]
        [MinLength(17, ErrorMessage = "Chassi deve ter 17 caracteres")]
        [MaxLength(17, ErrorMessage = "Chassi deve ter 17 caracteres")]
        public string Chassi { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "Cor do veículo é obrigatória")]
        [MinLength(2, ErrorMessage = "Tamanho mínimo de caracteres não atingido")]
        [MaxLength(50, ErrorMessage = "Tamanho máximo de caracteres atingido")]
        public string Color { get; set; }

        [Display(Name = "Tipo do Veículo")]
        [Required(ErrorMessage = "Tipo do veículo é obrigatório")]
        public int VehicleTypeId { get; set; }

        public Domain.Validations.ValidationResult ValidationResult { get; set; }
    }
}