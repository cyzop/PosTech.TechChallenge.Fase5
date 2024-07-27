using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortFolio.PortFolioWeb.Server.Services;
using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly ILogger<AtivoController> _logger;
        private readonly AtivosAPI _ativoApi;

        public AtivoController(ILogger<AtivoController> logger, AtivosAPI ativoApi)
        {
            _logger = logger;
            _ativoApi = ativoApi;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AtivoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<AtivoDao>> Get()
        {
            return await _ativoApi.GetAtivosAsync();
        }
    }
}
