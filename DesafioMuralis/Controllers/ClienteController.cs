using DesafioMuralis.Applications.ViewModel;
using DesafioMuralis.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMuralis.Controllers
{
    [ApiController]
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> SalvarCliente(ClienteViewModel cliente)
        {
            await _repository.SalvarNovoCliente(cliente);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            return Ok(await _repository.ListarClientes());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            return Ok(await _repository.BuscarPorId(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePorId(int id)
        {
            await _repository.DeletePorId(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(int id, ClienteViewModel viewModel)
        {
            await _repository.AtualizarCliente(id, viewModel);
            return Ok();
        }

        [HttpGet("{pageNumber}/{pageQuantity}")]
        public async Task<IActionResult> ListarClientesPaginacao(int pageNumber, int pageQuantity)
        {
            return Ok(await _repository.ListarClientesPaginacao(pageNumber, pageQuantity));
        }

    }
}
