using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolioWeb.Server.Services;
using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ClienteAPI _clienteApi;

        public ClienteController(ILogger<ClienteController> logger, ClienteAPI clienteApi)
        {
            _logger = logger;
            _clienteApi = clienteApi;
        }

        [HttpGet("ClientePorEmail/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ClienteDao> Get([FromRoute] string email)
        {
            var ret = await _clienteApi.GetClienteAsync(email);
            return ret; 
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClienteDao>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(ClienteDao cliente)
        {
            if (ModelState.IsValid)
            {
                var x = await _clienteApi.PostClienteAsync(cliente);
                return Ok(x);
            }
            else
                return BadRequest("Informações inválidas para o cliente");
        }
    }
}
