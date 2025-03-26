using DesafioLocacaoImoveis.Api.Domain.Entities;
using DesafioLocacaoImoveis.Api.Domain.Services;
using DesafioLocacaoImoveis.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioLocacaoImoveis.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly ILocacaoImoveisRepositorie _ilocacaoImoveisRepositorie;
        private readonly ViaCepService _viaCepService;

        public ImoveisController(ILocacaoImoveisRepositorie locacaoImoveisRepositorie, ViaCepService viaCepService)
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
        public async Task<ActionResult<Imoveis>> ObterImoveisPorId(Guid id)
        {
            Imoveis imovel = await _ilocacaoImoveisRepositorie.ObterImovelPorId(id);

            if (imovel == null)
                return NotFound($"Imóvel não encontrado.");

            return Ok(imovel);
        }

        [HttpPost]
        public async Task<ActionResult<Imoveis>> Cadastrar([FromBody] Imoveis imovelEntity)
        {
            try
            {
                var enderecoViaCep = await _viaCepService.ObterEnderecoPorCep(imovelEntity.Cep);

                if (enderecoViaCep != null)
                {
                    imovelEntity.Adress = enderecoViaCep.Logradouro;
                    imovelEntity.Neighborhood = enderecoViaCep.Bairro;
                    imovelEntity.City = enderecoViaCep.Localidade;
                    imovelEntity.State = enderecoViaCep.Uf;
                }

                Imoveis imovel = await _ilocacaoImoveisRepositorie.Adicionar(imovelEntity);
                return CreatedAtAction(nameof(ObterImoveisPorId), new { id = imovel.Id }, imovel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cadastrar imóvel: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Imoveis>> Atualizar(Guid id, [FromBody] Imoveis imovelEntity)
        {
            try
            {
                var enderecoViaCep = await _viaCepService.ObterEnderecoPorCep(imovelEntity.Cep);

                if (enderecoViaCep != null)
                {
                    imovelEntity.Adress = enderecoViaCep.Logradouro;
                    imovelEntity.Neighborhood = enderecoViaCep.Bairro;
                    imovelEntity.City = enderecoViaCep.Localidade;
                    imovelEntity.State = enderecoViaCep.Uf;
                }

                var imovelAtualizado = await _ilocacaoImoveisRepositorie.Atualizar(imovelEntity, id);
                return Ok(imovelAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar imóvel: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            try
            {
                bool deletado = await _ilocacaoImoveisRepositorie.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"Não foi possível deletar o imóvel: {ex.Message}");
            }
        }

    }
}
