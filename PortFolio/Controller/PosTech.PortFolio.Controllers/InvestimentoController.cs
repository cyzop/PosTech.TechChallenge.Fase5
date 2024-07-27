using PosTech.PortFolio.Adapter;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases.Transacao;

namespace PosTech.PortFolio.Controllers
{
    public class InvestimentoController : IInvestimentoController
    {
        private readonly ITransacaoGateway _transacaoGateway;

        public InvestimentoController(ITransacaoGateway transacaoGateway)
        {
            _transacaoGateway = transacaoGateway;
        }

        public List<InvestimentoDao> ListarAtivosInvestidos(PortFolioDao portFolio)
        {
            //negociacoes do ativo 
            var historicoTransacoes = _transacaoGateway.ObterPorPortFolio(portFolio.Id);

            //Contabilizar ativos da carteira
            ContabilizarAtivoInvestimentoUseCase contabilizarAtivo = new ContabilizarAtivoInvestimentoUseCase(historicoTransacoes);
            var investimentosPortfolio = contabilizarAtivo.CalcularAtivos();

            return investimentosPortfolio.Select(i=> InvestimentoDaoAdapter.GetDaoFromEntity(i)).ToList();
        }
    }
}
