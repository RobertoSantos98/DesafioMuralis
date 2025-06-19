using DesafioMuralis.Applications.ViewModel;
using DesafioMuralis.Domain.DTOs;

namespace DesafioMuralis.Domain.Models
{
    public interface IClienteCRUDRepository
    {
        Task<List<ClienteDTO>> listarClientes();
        Task<ClienteDTO> ListarPorId(int id);
        Task<List<ClienteDTO>> ListarPorNome(string nome);
        Task Delete(int id);
    }
}
