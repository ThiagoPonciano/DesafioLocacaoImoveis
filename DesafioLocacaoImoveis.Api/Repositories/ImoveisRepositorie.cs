using DesafioLocacaoImoveis.Api.Data;
using DesafioLocacaoImoveis.Api.Domain.Entities;
using DesafioLocacaoImoveis.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioLocacaoImoveis.Api.Repositories
{
    public class ImoveisRepositorie : ILocacaoImoveisRepositorie
    {
        private readonly LocacaoImoveisDbContext _dbContext;
        public ImoveisRepositorie(LocacaoImoveisDbContext locacaoImoveisDbContext)
        {
            _dbContext = locacaoImoveisDbContext;
        }

        public async Task<Imoveis> ObterImovelPorId(Guid id)
        {
            return await _dbContext.Imoveis.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Imoveis>> ObterImoveis()
        {
            return await _dbContext.Imoveis.ToListAsync();
        }

        public async Task<Imoveis> Adicionar(Imoveis imoveis)
        {
            await _dbContext.Imoveis.AddAsync(imoveis);
            await _dbContext.SaveChangesAsync();

            return imoveis;
        }

        public async Task<Imoveis> Atualizar(Imoveis imoveis, Guid id)
        {
            Imoveis imovelPorId = await ObterImovelPorId(id);

            if(imovelPorId == null)
            {
                throw new Exception($"O imovel de ID: {id} não foi encontrado!");
            }

            imovelPorId.Adress = imoveis.Adress;
            imovelPorId.Cep = imoveis.Cep;
            imovelPorId.Value = imoveis.Value;
            imovelPorId.Status = imoveis.Status;
            imovelPorId.Neighborhood = imoveis.Neighborhood;
            imovelPorId.City = imoveis.City;
            imovelPorId.State = imoveis.State;

            _dbContext.Imoveis.Update(imovelPorId);
            await _dbContext.SaveChangesAsync();

            return imovelPorId;
        }

        public async Task<bool> Deletar(Guid id)
        {
            Imoveis imovelPorId = await ObterImovelPorId(id);

            if (imovelPorId == null)
            {
                throw new Exception($"O imovel de ID: {id} não foi encontrado!");
            }

            _dbContext.Imoveis.Remove(imovelPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }



    }
}
