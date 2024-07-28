using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolioWeb.Server.Services;
using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly PortfoliosApi _portfolioApi;

        public PortfolioController(ILogger<PortfolioController> logger, PortfoliosApi portfolioApi)
        {
            _logger = logger;
            _portfolioApi = portfolioApi;
        }

        [HttpGet("PortfoliosUsuario/{userKey}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PortFolioDao>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<PortFolioDao>> Get([FromRoute] string userKey)
        {
            return await _portfolioApi.GetPortFoliosAsync(userKey);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortFolioDao))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<PortFolioDao> GetPorId([FromRoute] string id)
        {
            return await _portfolioApi.GetPortFolioPorIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PortFolioDao portFolio)
        {
            if (ModelState.IsValid)
            {
                var x = await _portfolioApi.PostAsync(portFolio);
                return Ok(x);
            }
            else
                return BadRequest("Portfolio inválido");
        }

        [HttpPut]
        public async Task<IActionResult> Put(PortFolioDao portFolio)
        {
            if (ModelState.IsValid)
            {
                var x = await _portfolioApi.PutAsync(portFolio);
                return Ok(x);
            }
            else
                return BadRequest("Portfolio inválido");
        }
    }
}
