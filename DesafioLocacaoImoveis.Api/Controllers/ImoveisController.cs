using DesafioLocacaoImoveis.Api.Domain.Entities;
using DesafioLocacaoImoveis.Api.Repositories.Interfaces;
using DesafioLocacaoImoveis.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.IsisMtt.X509;

namespace DesafioLocacaoImoveis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly ILocacaoImoveisRepositorie _ilocacaoImoveisRepositorie;
        private readonly ViaCEPService _viaCepService;

        public ImoveisController(ILocacaoImoveisRepositorie locacaoImoveisRepositorie, ViaCEPService viaCepService)
        {
            _ilocacaoImoveisRepositorie = locacaoImoveisRepositorie;
            _viaCepService = viaCepService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Imoveis>>> ObterImoveis()
        {
            List<Imoveis> imoveis = await _ilocacaoImoveisRepositorie.ObterImoveis();
            return Ok(imoveis);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Imoveis>> ObterImoveisPorId(int id)
        {
            Imoveis imovel = await _ilocacaoImoveisRepositorie.ObterImovelPorId(id);
            return Ok(imovel);
        }

        [HttpPost]
        public async Task<ActionResult<Imoveis>> Cadastrar([FromBody] Imoveis imovelEntity)
        {
            var enderecoViaCep = await _viaCepService.ObterEnderecoPorCep(imovelEntity.Cep);

            if(enderecoViaCep != null)
            {
                imovelEntity.Adress = enderecoViaCep.Logradouro;
                imovelEntity.Neighborhood = enderecoViaCep.Bairro;
                imovelEntity.City = enderecoViaCep.Localidade;
                imovelEntity.State = enderecoViaCep.Uf;
            }

            Imoveis imovel = await _ilocacaoImoveisRepositorie.Adicionar(imovelEntity);
            return Ok(imovel);
        }

    }
}
