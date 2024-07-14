using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;

namespace PosTech.PortFolio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IMercadoFinanceiroController _controller;
        private readonly ILogger<InvestimentoController> _logger;

        public InvestimentoController(IMercadoFinanceiroController mercadoFinanceiroController, ILogger<InvestimentoController> logger)
        {
            _controller = mercadoFinanceiroController;
            _logger = logger;
        }


        [HttpGet("ListarAtivos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CotacaoAtivoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAtivos()
        {
            try
            {
                var ativos = _controller.ListarAtivos();
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Cotação Ativos length {quantidade}", quantidade);

                if (ativos?.Count() > 0)
                    return Ok(ativos);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
