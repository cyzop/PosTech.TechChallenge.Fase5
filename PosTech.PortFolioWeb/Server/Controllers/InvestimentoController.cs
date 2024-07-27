using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolioWeb.Server.Services;
using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly ILogger<InvestimentoController> _logger;
        private readonly CotacaoAtivosAPI _cotacaoApi;
        private readonly InvestimentoAPI _investimentoApi;

        public InvestimentoController(ILogger<InvestimentoController> logger, CotacaoAtivosAPI cotacaoApi, InvestimentoAPI investimentoApi)
        {
            _logger = logger;
            _cotacaoApi = cotacaoApi;
            _investimentoApi = investimentoApi;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CotacaoAtivoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<CotacaoAtivoDao>> Get()
        {
            return await _cotacaoApi.GetAtivosAsync();
        }

        [HttpGet("Ativos/{portFolioId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<InvestimentoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<InvestimentoDao>> GetAtivos([FromRoute] string portFolioId)
        {
            return await _investimentoApi.GetAtivosAsync(portFolioId);
        }
    }
}
