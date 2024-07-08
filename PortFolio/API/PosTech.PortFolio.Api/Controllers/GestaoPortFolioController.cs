using Microsoft.AspNetCore.Mvc;

namespace PosTech.PortFolio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestaoPortFolioController : ControllerBase
    {
        private readonly ILogger<GestaoPortFolioController> _logger;

        public GestaoPortFolioController(ILogger<GestaoPortFolioController> logger)
        {
            _logger = logger;
        }

        //Listar Portifolio do usuario
        //Realizar transação de compra 
        //Realizar transação de venda (só o que tem)
        //Listar ativos disponíveis
    }
}
