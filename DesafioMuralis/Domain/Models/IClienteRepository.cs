using DesafioMuralis.Applications.ViewModel;
using DesafioMuralis.Domain.DTOs;

namespace DesafioMuralis.Domain.Models
{
    public interface IClienteRepository
    {
        public Task SalvarNovoCliente(ClienteViewModel cliente);
        public Task<List<ClienteDTO>> ListarClientes();
        public Task<List<ClienteDTO>> ListarClientesPaginacao(int pageNumber, int pageQuantity);
        public Task<ClienteDTO> BuscarPorId(int id);
        public Task DeletePorId(int id);
        public Task AtualizarCliente(int id, ClienteViewModel cliente);
    }
}
