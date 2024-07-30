using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;

namespace Postech.PortFolio.Ativo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly ILogger<AtivoController> _logger;
        private readonly IAtivoController _controller;
        

        public AtivoController(ILogger<AtivoController> logger, IAtivoController controller)
        {
            _logger = logger;
            _controller = controller;
        }


        [HttpGet("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AtivoDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAtivos()
        {
            try
            {
                var ativos = _controller.ListarDisponiveis();
                var quantidade = ativos?.Count() ?? 0;

                _logger.LogInformation("Get Ativos length {quantidade}", quantidade);

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
