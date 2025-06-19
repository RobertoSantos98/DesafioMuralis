using DesafioMuralis.Applications.ViewModel;

namespace DesafioMuralis.Domain.Models
{
    public interface IClienteRepository
    {
        public Task SalvarNovoCliente(ClienteViewModel cliente);
        public Task<List<Cliente>> ListarClientes();

    }
}
