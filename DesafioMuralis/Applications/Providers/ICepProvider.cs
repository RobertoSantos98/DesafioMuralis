using DesafioMuralis.Domain.DTOs;

namespace DesafioMuralis.Applications.Providers
{
    public interface ICepProvider
    {
        public Task<EnderecoDTO> RecuperarEndereco(string cep);
    }
}
