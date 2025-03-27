using DesafioLocacaoImoveis.Api.Responses;
using System.Text.Json;

namespace DesafioLocacaoImoveis.Api.Domain.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResponse> ObterEnderecoPorCep(string cep)
        {
            cep = new string(cep.Where(char.IsDigit).ToArray());

            if(cep.Length != 8)
            {
                throw new ArgumentException("CEP Inválido. Deve conter apenas números.");
            }

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var serializer = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                return JsonSerializer.Deserialize<ViaCepResponse>(content, serializer);
            }

            return null;
        }
    }
}
