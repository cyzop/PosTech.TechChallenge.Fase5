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

        [HttpGet("{portfolioId}")]
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
                return BadRequest(ex.Message);
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
                        Usuario = new UsuarioDao(portFolio.ClienteId)
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
                    return BadRequest(ex.Message);
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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortFolioDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostPortFolio(PortFolioModel portFolio)
        {
            _logger.LogInformation($"Post PortFolio {portFolio.Nome}");
            if (ModelState.IsValid)
            {
                try
                {
                    PortFolioDao dao = new PortFolioDao()
                    {
                        Id = portFolio.Id,
                        Nome = portFolio.Nome,
                        Descricao = portFolio.Descricao,
                        Usuario = new UsuarioDao(portFolio.ClienteId)
                    };

                    var registro = _controller.AtualizarPortFolio(dao);

                    if (registro != null)
                        return Ok(registro);
                    else
                        return StatusCode(StatusCodes.Status204NoContent);//NoContent
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    return BadRequest(ex.Message);
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

        [HttpGet("PortFoliosUsuario/{userMail}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerator<PortFolioDao>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPorUsuarioId(string userMail)
        {
            //incluir um portfolio para o usuário
            try
            {
                _logger.LogInformation($"PortFoliosUsuario {userMail}");
                var registros = _controller.ListarPorUsuario(userMail);

                if (registros?.Count() > 0)
                    return Ok(registros);
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
