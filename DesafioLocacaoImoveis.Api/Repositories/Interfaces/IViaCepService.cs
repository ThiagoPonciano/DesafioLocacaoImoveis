using DesafioLocacaoImoveis.Api.Responses;

namespace DesafioLocacaoImoveis.Api.Repositories.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepResponse> ObterEnderecoPorCep(string cep);
    }
}
