using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolio.Api.Model;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.DAO;

namespace PosTech.PortFolio.Api.Controllers
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

        //[HttpGet("{Id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteModel))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GetUsuarioPorId(string Id)
        //{
        //    try
        //    {
        //        var usuario = _usuarioController.ObterUsuarioPorId(Id);

        //        _logger.LogInformation($"Get usuário por Id {Id}");

        //        if (usuario != null)
        //            return Ok(usuario);
        //        else
        //            return StatusCode(StatusCodes.Status204NoContent);//NoContent
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet("Email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsuarioPorEmail(string email)
        {
            try
            {
                var usuario = _usuarioController.ObterUsuarioPorEmail(email);

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

        ///// <summary>
        ///// Inclusão de um novo usuário
        ///// </summary>
        ///// <param name="usuario">Json representando as informações do Usuario</param>
        ///// <response code="200">Usuuário incluído com sucesso</response>
        ///// <response code="400">Falha na inclusão do Usuuário</response>
        //[HttpPut("Incluir")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteModel))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> PutUsuario(NovoClienteModel usuario)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //update
        //            _logger.LogInformation("Put usuário {Nome} {Email}", usuario.Nome, usuario.Email);
        //            var novousuarioDao = new NovoUsuarioDao(usuario.Nome, usuario.Email, usuario.Senha);
        //            var usuariocriado = _usuarioController.IncluirUsuario(novousuarioDao);

        //            return Ok(usuariocriado);
        //        }
        //        else
        //        {
        //            var erros = ModelState.Values
        //                .Where(x => x.ValidationState == ModelValidationState.Invalid)
        //                .Select(x => x.Errors?.FirstOrDefault()?.ErrorMessage).ToList();
        //            return BadRequest(new
        //            {
        //                PayloadErros = erros
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return BadRequest(ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Alteração de um usuário
        ///// </summary>
        ///// <param name="usuario">Json representando as informações do Usuario</param>
        ///// <response code="200">Usuário atualizado com sucesso</response>
        ///// <response code="400">Falha na atualização do Usuário</response>

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


        //[HttpGet("List")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UsuarioDao>))]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GetClientes()
        //{
        //    try
        //    {
        //        var usuarios = _usuarioController.ListarUsuarios();
        //        var quantidade = usuarios?.Count() ?? 0;

        //        _logger.LogInformation("Get clientes length {quantidade}", quantidade);

        //        if (usuarios?.Count() > 0)
        //            return Ok(usuarios);
        //        else
        //            return StatusCode(StatusCodes.Status204NoContent);//NoContent
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message, ex);
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
