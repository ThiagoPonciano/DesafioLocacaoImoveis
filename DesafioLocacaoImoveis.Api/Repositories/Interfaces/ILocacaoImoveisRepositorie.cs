using DesafioLocacaoImoveis.Api.Domain.Entities;

namespace DesafioLocacaoImoveis.Api.Repositories.Interfaces
{
    public interface ILocacaoImoveisRepositorie
    {
        Task<List<Imoveis>> ObterImoveis();
        Task<Imoveis> ObterImovelPorId(Guid id);
        Task<Imoveis> Adicionar(Imoveis imoveis);
        Task<Imoveis> Atualizar(Imoveis imoveis, Guid id);
        Task<bool> Deletar(Guid id);

    }
}
