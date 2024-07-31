using PosTech.PortFolio.Adapter;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases.Investimento;

namespace PosTech.PortFolio.Controllers
{
    public class InvestimentoController : IInvestimentoController
    {
        private readonly ITransacaoGateway _transacaoGateway;
        private readonly IMercadoFinanceiroGateway _mercadoFinanceiroGateway;
        private readonly IAtivoGateway _ativoGateway;

        public InvestimentoController(ITransacaoGateway transacaoGateway, IMercadoFinanceiroGateway mercadoFinanceiroGateway, IAtivoGateway ativoGateway)
        {
            _transacaoGateway = transacaoGateway;
            _mercadoFinanceiroGateway = mercadoFinanceiroGateway;
            _ativoGateway = ativoGateway;
        }

        public List<InvestimentoDao> ListarAtivosInvestidos(PortFolioDao portFolio)
        {
            //negociacoes do ativo 
            var historicoTransacoes = _transacaoGateway.ObterPorPortFolio(portFolio.Id);

            //Contabilizar ativos da carteira
            ContabilizarAtivoInvestimentoUseCase contabilizarAtivo = new ContabilizarAtivoInvestimentoUseCase(historicoTransacoes);
            var investimentosPortfolio = contabilizarAtivo.CalcularAtivos();

            var ativosDisponiveis = _ativoGateway.ObterTodos();
            var cotacaoAtivos = _mercadoFinanceiroGateway.GetCotacoes(ativosDisponiveis);

            //Atualizar com cotaão dos ativos
            AtualizarCotacaoAtivoUseCase contabilitaValosInvestimento = new AtualizarCotacaoAtivoUseCase(investimentosPortfolio, cotacaoAtivos);
            var investimentosAtualizados = contabilitaValosInvestimento.AtualizarCotacaoInvestimentos();

            return investimentosAtualizados.Select(i=> InvestimentoDaoAdapter.GetDaoFromEntity(i)).ToList();
        }
    }
}
