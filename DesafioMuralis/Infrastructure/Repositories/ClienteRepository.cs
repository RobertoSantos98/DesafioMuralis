using AutoMapper;
using DesafioMuralis.Applications.Providers;
using DesafioMuralis.Applications.ViewModel;
using DesafioMuralis.Domain.DTOs;
using DesafioMuralis.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioMuralis.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ConnectionContext _context;
        private readonly ICepProvider _cepProvider;
        private readonly IMapper _mapper;

        public ClienteRepository(ConnectionContext context, ICepProvider cepProvider, IMapper mapper)
        {
            _context = context;
            _cepProvider = cepProvider;
            _mapper = mapper;
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

        public async Task<List<ClienteDTO>> ListarClientes()
        {

            var response = await _context.Clientes
                .Include(c => c.Contatos)
                .Include(c => c.Endereco)
                .ToListAsync();

            return _mapper.Map<List<ClienteDTO>>(response);
        }

        public async Task<List<ClienteDTO>> ListarClientesPaginacao(int pageNumber, int pageQuantity)
        {
            var response = await _context.Clientes
                .OrderBy(c => c.Id)
                .Skip((pageNumber - 1)* pageQuantity)
                .Take(pageQuantity)
                .ToListAsync();

            return _mapper.Map<List<ClienteDTO>>(response);
        }

        public async Task<ClienteDTO> BuscarPorId(int id)
        {
            var response = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<ClienteDTO>(response);       
        }

        public async Task DeletePorId(int id)
        {
            var response = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Cliente não foi encontrado!");

            _context.Clientes.Remove(response);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarCliente(int id, ClienteViewModel cliente)
        {
            var response = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Cliente não foi encontrado!");
            var cepResponse = await _cepProvider.RecuperarEndereco(cliente.Cep) ?? throw new Exception("Endereço não encontrado, Verifique o CEP novamente");

            response.AlterarNome(cliente.Nome);

            response.AtualizarEndereco( (new Endereco
                (
                    cliente.Cep,
                    cliente.Logradouro,
                    cepResponse.Cidade,
                    cliente.Numero,
                    cliente.Complemento
                )) );

            response.AtualizarContatos( _mapper.Map<List<Contato>>(cliente.Contatos) );

            _context.Clientes.Update(response);
            await _context.SaveChangesAsync();
        }
    }
}
