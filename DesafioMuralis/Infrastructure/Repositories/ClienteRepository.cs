using DesafioMuralis.Applications.Providers;
using DesafioMuralis.Applications.ViewModel;
using DesafioMuralis.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMuralis.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConnectionContext _context;
        private readonly ICepProvider _cepProvider;

        public ClienteRepository(ConnectionContext context, ICepProvider cepProvider)
        {
            _context = context;
            _cepProvider = cepProvider;
        }

        public async Task SalvarNovoCliente(ClienteViewModel cliente)
        {

            var responseCepProvider = await _cepProvider.RecuperarEndereco(cliente.Cep);

            if (string.IsNullOrEmpty(responseCepProvider.Cidade))
            {
                throw new Exception("Endereço inválido ou incompleto!");
            }

            var newCliente = new Cliente
            (
                cliente.Nome,
                cliente.Contatos.Select(c => new Contato
                (
                    c.Tipo,
                    c.Texto
                )).ToList(),
                new Endereco
                (
                    cliente.Cep,
                    cliente.Logradouro,
                    responseCepProvider.Cidade,
                    cliente.Numero,
                    cliente.Complemento
                )
            );

            await _context.AddAsync(newCliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> ListarClientes()
        {
            return await _context.Clientes.ToListAsync();

        }
    }
}
