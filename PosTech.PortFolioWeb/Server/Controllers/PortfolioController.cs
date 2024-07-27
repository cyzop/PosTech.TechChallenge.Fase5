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
    }
}
