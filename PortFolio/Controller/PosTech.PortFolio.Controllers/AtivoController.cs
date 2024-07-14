using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;

namespace PosTech.PortFolio.Controllers
{
    public class AtivoController : IAtivoController
    {
        readonly IAtivoGateway _ativosGateway;

        public AtivoController(IAtivoGateway ativosGateway)
        {
            _ativosGateway = ativosGateway;
        }

        public IEnumerable<AtivoDao> ListarDisponiveis()
        {
            List<AtivoDao> ret = new List<AtivoDao>();
            _ativosGateway.ObterTodos().ForEach(e => {
                ret.Add(new AtivoDao { Codigo = e.Codigo, Nome = e.Nome, Tipo = e.Tipo.ToString() });
            });
               
            return ret;
        }
    }
}
