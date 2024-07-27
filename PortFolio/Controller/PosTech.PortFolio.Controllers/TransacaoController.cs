using PosTech.PortFolio.Adapter;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases.Transacao;

namespace PosTech.PortFolio.Controllers
{
    public class TransacaoController : ITransacaoController
    {
        readonly IAtivoGateway _ativosGateway;
        readonly IPortFolioGateway _portfolioGateway;
        readonly ITransacaoGateway _transacaoGateway;

        public TransacaoController(IAtivoGateway ativosGateway, IPortFolioGateway portfolioGateway, ITransacaoGateway transacaoGateway)
        {
            _ativosGateway = ativosGateway;
            _portfolioGateway = portfolioGateway;
            _transacaoGateway = transacaoGateway;
        }

        public IEnumerable<TransacaoDao> ListarPorPortFolio(string portfolioId)
        {
            var transacoes = _transacaoGateway.ObterPorPortFolio(portfolioId);

            //listar use case
            ListarTransacoesUseCase listarUseCase = new ListarTransacoesUseCase(transacoes);

            var transacoesRetorno = listarUseCase.Listar();

            return transacoesRetorno.Select(t => TransacaoDaoAdapter.GetDaoFromEntity(t));
        }

        public IEnumerable<TransacaoDao> ListarTodos()
        {
            var transacoes = _transacaoGateway.ObterTodos();

            //listar use case
            ListarTransacoesUseCase listarUseCase = new ListarTransacoesUseCase(transacoes);

            var transacoesRetorno = listarUseCase.Listar();

            return transacoesRetorno
                .Select(t => TransacaoDaoAdapter.GetDaoFromEntity(t));
        }

        public TransacaoDao ObterPorId(string id)
        {
            var transacao = _transacaoGateway.ObterPorId(id);
            return TransacaoDaoAdapter.GetDaoFromEntity(transacao);
        }

        public TransacaoDao RegistrarCompra(PortFolioDao portFolioDao, AtivoTransacaoDao ativoDao)
        {
            var portFolio = _portfolioGateway.ObterPorId(portFolioDao.Id);
            
            //ativo por codigo
            var ativo = _ativosGateway.ObterPorCodigo(ativoDao.Codigo);

            //transacao use case
            RegistrarTransacaoCompraUseCase registroTransacao = new RegistrarTransacaoCompraUseCase(portFolio, ativo, ativoDao.Quantidade, ativoDao.Preco);
            var transacao = registroTransacao.FinalizarTransacao();

            //transacao gateway (registrar a transacao)
            _transacaoGateway.RegistrarTransacao(transacao);

            return TransacaoDaoAdapter.GetDaoFromEntity(transacao);
        }
        public TransacaoDao RegistrarVenda(PortFolioDao portFolioDao, AtivoTransacaoDao ativoDao)
        {
            var portFolio = _portfolioGateway.ObterPorId(portFolioDao.Id);

            //ativo por codigo
            var ativo = _ativosGateway.ObterPorCodigo(ativoDao.Codigo);

            //negociacoes do ativo 
            var carteira = _transacaoGateway.ObterPorAtivoePortFolio(ativo.Id, portFolio.Id);

            //Contabilizar carteira do ativo
            ContabilizarAtivoInvestimentoUseCase contabilizarAtivo = new ContabilizarAtivoInvestimentoUseCase(carteira);
            var saldoAtivoNegociado = contabilizarAtivo.CalcularQuantidadePorAtivo(ativo);

            //transacao use case
            RegistrarTransacaoVendaUseCase registroTransacao = new RegistrarTransacaoVendaUseCase(portFolio, ativo, ativoDao.Quantidade, ativoDao.Preco, saldoAtivoNegociado);
            var transacao = registroTransacao.FinalizarTransacao();

            //transacao gateway (registrar a transacao)
            _transacaoGateway.RegistrarTransacao(transacao);

            return TransacaoDaoAdapter.GetDaoFromEntity(transacao);
        }
        

    }
}
