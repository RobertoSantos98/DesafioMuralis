
using DesafioMuralis.Domain.DTOs;
using DesafioMuralis.Domain.Models;
using System.Text.Json;

namespace DesafioMuralis.Applications.Providers
{
    public class ViaCepService : ICepProvider
    {

        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoDTO?> RecuperarEndereco(string cep)
        {
            try
            {

                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                if (response == null)
                {
                    throw new Exception("Endereço não encontrado");
                }

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<EnderecoDTO>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });

            } catch(Exception ex)
            {
                throw new Exception("Erro ao buscar Endereço: ", ex);
            }
        }
    }
}
