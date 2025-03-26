using System.ComponentModel;

namespace DesafioLocacaoImoveis.Api.Enums
{
    public enum StatusImovel
    {
        [Description("Disponível para Locação")]
        Disponivel = 1,
        [Description("Em Processo de Locação")]
        EmLocacao = 2,
        [Description("Indisponível para Locação")]
        Indisponivel = 3
    }
}
