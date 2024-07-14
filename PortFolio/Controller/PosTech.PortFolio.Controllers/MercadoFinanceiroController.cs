using PosTech.PortFolio.Adapter;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;

namespace PosTech.PortFolio.Controllers
{
    public class MercadoFinanceiroController : IMercadoFinanceiroController
    {
        private readonly IAtivoGateway _ativoGateway;
        private readonly IMercadoFinanceiroGateway _mercadoFinanceiroGateway;

        public MercadoFinanceiroController(IAtivoGateway ativoGateway, IMercadoFinanceiroGateway mercadoFinanceiroGateway)
        {
            _ativoGateway = ativoGateway;
            _mercadoFinanceiroGateway = mercadoFinanceiroGateway;
        }

        public IEnumerable<CotacaoAtivoDao> ListarAtivos()
        {
            var ativosDisponiveis = _ativoGateway.ObterTodos();
            var cotacaoAtivos = _mercadoFinanceiroGateway.GetCotacoes(ativosDisponiveis);

            return cotacaoAtivos.Select(c => CotacaoAtivoDaoAdapter.GetDaoFromEntity(c));
        }
    }
}
