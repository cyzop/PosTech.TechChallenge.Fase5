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
        private readonly IInvestimentoController _investimentoController;
        private readonly IPortFolioController _portFolioController;

        public InvestimentoController(IMercadoFinanceiroController mercadoFinanceiroController, ILogger<InvestimentoController> logger, IInvestimentoController investimentoController, IPortFolioController portFolioController)
        {
            _controller = mercadoFinanceiroController;
            _logger = logger;
            _investimentoController = investimentoController;
            _portFolioController = portFolioController;
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


        [HttpGet("ListarAtivosPortfolio/{portFolioId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InvestimentoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAtivosInvestidos(string portFolioId)
        {
            try
            {
                var portFolio = _portFolioController.ObterPorId(portFolioId);

                var ativos = _investimentoController.ListarAtivosInvestidos(portFolio);
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Listar todos os Ativos do PorfFolio, length {quantidade}", quantidade);

                if (ativos?.Count() > 0)
                    return Ok(ativos);
                else
                    return Ok(new List<InvestimentoDao>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
