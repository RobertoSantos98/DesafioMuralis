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
            return Ok( await _repository.ListarClientes());
        }


    }
}
