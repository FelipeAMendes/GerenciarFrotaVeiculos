using System.ComponentModel.DataAnnotations;

namespace ManageFleet.Application.ViewModels
{
    public class VehicleListViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Chassi")]
        public string Chassi { get; set; }

        [Display(Name = "Cor")]
        public string Color { get; set; }

        [Display(Name = "Tipo do Veículo")]
        public string NomeTipoVeiculo { get; set; }

        [Display(Name = "Quantidade de Passageiros")]
        public string QuantidadePassageiros { get; set; }
    }
}