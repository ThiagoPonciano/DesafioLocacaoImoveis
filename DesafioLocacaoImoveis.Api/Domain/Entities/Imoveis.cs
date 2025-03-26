using DesafioLocacaoImoveis.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioLocacaoImoveis.Api.Domain.Entities
{
    public class Imoveis
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Cep { get; set; }

        public string Adress { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        [Range(0,double.MaxValue)]
        public double Value { get; set; }

        public StatusImovel Status { get; set; }

    }
}
