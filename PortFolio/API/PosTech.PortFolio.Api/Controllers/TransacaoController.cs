using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PosTech.PortFolio.Api.Model;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;

namespace PosTech.PortFolio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoController _controller;

        public TransacaoController(ILogger<TransacaoController> logger, ITransacaoController controller)
        {
            this._logger = logger;
            _controller = controller;
        }

        [HttpPost("Comprar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransacaoDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTransacaoComprar(TransacaoModel transacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portFolio = new PortFolioDao()
                    {
                        Id = transacao.PortFolioId
                    };
                    var ativoTransacao = new AtivoTransacaoDao()
                    {
                        Codigo = transacao.AtivoId,
                        Preco = transacao.Preco,
                        Quantidade = transacao.Quantidade
                    };

                    var transacaoDao = _controller.RegistrarCompra(portFolio, ativoTransacao);

                    _logger.LogInformation($"Registrar transação compra Ativo {transacao.AtivoId} ");

                    if (transacaoDao != null)
                        return Ok(transacaoDao);
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

        [HttpPost("Vender")]
       // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransacaoDao))]
       // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTransacaoVender(TransacaoModel transacao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var portFolio = new PortFolioDao()
                    {
                        Id = transacao.PortFolioId
                    };
                    var ativoTransacao = new AtivoTransacaoDao()
                    {
                        Codigo = transacao.AtivoId,
                        Preco = transacao.Preco,
                        Quantidade = transacao.Quantidade
                    };

                    var transacaoDao = _controller.RegistrarVenda(portFolio, ativoTransacao);

                    _logger.LogInformation($"Registrar transação venda Ativo {transacao.AtivoId} ");

                    if (transacaoDao != null)
                        return Ok(transacaoDao);
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

        [HttpPost("Listar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TransacaoDao>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var transacoes = _controller.ListarTodos();
                var quantidade = transacoes?.Count() ?? 0;

                _logger.LogInformation("Listar Todas as Trnasações length {quantidade}", quantidade);

                if (transacoes?.Count() > 0)
                    return Ok(transacoes);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Listar/{portFolioId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TransacaoDao>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarPorPortFolio(string portFolioId)
        {
            try
            {
                var transacoes = _controller.ListarPorPortFolio(portFolioId);
                var quantidade = transacoes?.Count() ?? 0;

                _logger.LogInformation("Listar Todas as Transações do PorfFolio, length {quantidade}", quantidade);

                if (transacoes?.Count() > 0)
                    return Ok(transacoes);
                else
                    return StatusCode(StatusCodes.Status204NoContent);//NoContent
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{transacaoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransacaoDao))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListarPorId(string transacaoId)
        {
            try
            {
                _logger.LogInformation("Transacao.ListarPorId {transacaoId}", transacaoId);
                var transacao = _controller.ObterPorId(transacaoId);
                if (transacao != null)
                    return Ok(transacao);
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
