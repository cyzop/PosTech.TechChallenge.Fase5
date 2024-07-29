using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Cliente.Api.Model;
using PosTech.PortFolio.Interfaces.Controller;

namespace PosTech.PortFolio.Cliente.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteController _usuarioController;

        public ClienteController(ILogger<ClienteController> logger, IClienteController usuarioController)
        {
            _logger = logger;
            _usuarioController = usuarioController;
        }

        [HttpGet("Email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsuarioPorEmail(string email)
        {
            try
            {
                var usuario = _usuarioController.ObterUsuarioPorEmail(email);

                if (usuario == null)
                {
                    //cadastrar usuário (usuário novo que se autenticou)
                    var novousuario = _usuarioController.IncluirUsuario(new NovoUsuarioDao($"Convidado {DateTime.Now.Ticks}", email));
                    usuario = novousuario;
                }

                _logger.LogInformation($"Get usuário por Email {email}");

                if (usuario != null)
                    return Ok(usuario);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        // <summary>
        // Alteração de um usuário
        // </summary>
        // <param name="usuario">Json representando as informações do Usuario</param>
        // <response code="200">Usuário atualizado com sucesso</response>
        // <response code="400">Falha na atualização do Usuário</response>

        [HttpPost("Atualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateClienteModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostUsuario(UpdateClienteModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //update
                    _logger.LogInformation("Post usuário {Id} {Nome} {Email}", usuario.Id, usuario.Nome, usuario.Email);
                    var usuarioAlterar = new UsuarioDao(usuario.Id, usuario.Nome, usuario.Email);
                    var usuariocriado = _usuarioController.AtualizarUsuario(usuarioAlterar);

                    return Ok(usuariocriado);
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
