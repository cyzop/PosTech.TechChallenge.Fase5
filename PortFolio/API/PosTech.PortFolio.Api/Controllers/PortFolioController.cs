using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PosTech.PortFolio.Api.Model;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;

namespace PosTech.PortFolio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortFolioController : ControllerBase
    {
        private readonly ILogger<PortFolioController> _logger;
        private readonly IPortFolioController _controller;

        public PortFolioController(ILogger<PortFolioController> logger, IPortFolioController controller)
        {
            _logger = logger;
            _controller = controller;
        }

        [HttpGet("/{portfolioId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortFolioDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPortFolioPorId(string portfolioId)
        {
            try
            {
                var registro = _controller.ObterPorId(portfolioId);

                _logger.LogInformation("Get PortFolio {portfolioId}", portfolioId);

                if (registro != null)
                    return Ok(registro);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortFolioDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutPortFolio(PortFolioModel portFolio)
        {
            _logger.LogInformation($"Put PortFolio {portFolio.Nome}");
            if (ModelState.IsValid)
            {
                try
                {
                    PortFolioDao dao = new PortFolioDao()
                    {
                        Nome = portFolio.Nome,
                        Descricao = portFolio.Descricao,
                        UsuarioDao = new UsuarioDao(portFolio.ClienteId)
                    };

                    var registro = _controller.RegistrarPortFolio(dao);

                    if (registro != null)
                        return Ok(registro);
                    else
                        return StatusCode(StatusCodes.Status204NoContent);//NoContent
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return BadRequest(ex);
                }
            }
            else
            {
                var erros = ModelState.Values
                    .Where(x => x.ValidationState == ModelValidationState.Invalid)
                    .Select(x => x.Errors?.FirstOrDefault()?.ErrorMessage).ToList();
                return BadRequest(new
                {
                    PayloadErros = erros
                });
            }
        }


        [HttpGet("PortFoliosUsuario/{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerator<PortFolioDao>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPorUsuarioId(string usuarioId)
        {
            //incluir um portfolio para o usuário
            try
            {
                _logger.LogInformation($"PortFoliosUsuario {usuarioId}");
                var registros = _controller.ListarPorUsuario(usuarioId);

                if (registros?.Count() > 0)
                    return Ok(registros);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex);
            }

        }
    }
}
