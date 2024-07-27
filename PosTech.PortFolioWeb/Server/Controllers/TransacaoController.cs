using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolioWeb.Server.Services;
using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly TransacaoAPI _transacaoApi;

        public TransacaoController(ILogger<PortfolioController> logger, TransacaoAPI transacaoApi)
        {
            _logger = logger;
            _transacaoApi = transacaoApi;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TransacaoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<TransacaoDao>> Get([FromRoute] string id)
        {
            return await _transacaoApi.GetTransacoesAsync(id);
        }

        [HttpPost("Comprar")]
        public async Task<IActionResult> PostTransacaoCompra(NegociacaoAtivoDao negociacao)
        {
            if (ModelState.IsValid)
            {
                var x = await _transacaoApi.PostCompraAsync(negociacao);
                return Ok(x);
            }
            else
                return BadRequest("Transação inválida");

        }

        [HttpPost("Vender")]
        public async Task<IActionResult> PostTransacaoVenda(NegociacaoAtivoDao negociacao)
        {
            if (ModelState.IsValid)
            {
                var x = await _transacaoApi.PostVendaAsync(negociacao);
                return Ok(x);
            }
            else
                return BadRequest("Transação inválida");

        }
    }
}
