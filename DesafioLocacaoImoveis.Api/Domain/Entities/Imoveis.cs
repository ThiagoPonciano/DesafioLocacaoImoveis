using DesafioLocacaoImoveis.Api.Enums;

namespace DesafioLocacaoImoveis.Api.Domain.Entities
{
    public class Imoveis
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Cep { get; set; }
        public string Adress { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public double Value { get; set; }
        public StatusImovel Status { get; set; }

    }
}
