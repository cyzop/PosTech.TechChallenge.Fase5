using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases;

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

        public string RegistrarCompra(PortFolioDao portFolioDao, AtivoDao ativoDao)
        {
            var portFolio = _portfolioGateway.ObterPorId(portFolioDao.Id);
            
            //ativo por codigo
            var ativo = _ativosGateway.ObterPorCodigo(ativoDao.Codigo);

            //transacao use case
            RegistrarTransacaoCompraUseCase registroTransacao = new RegistrarTransacaoCompraUseCase(portFolio, ativo, ativoDao.Quantidade, ativoDao.Preco);
            var transacao = registroTransacao.FinalizarTransacao();

            //transacao gateway (registrar a transacao)
            _transacaoGateway.RegistrarTransacao(transacao);

            return string.Empty;
        }
        internal string RegistrarVenda(UsuarioDao clienteDao, List<AtivoDao> produtos)
        {
            //cliente gateway (obter por id)
            //ativos gateway (obter por codigo)
            //transacao use case
            //transacao gateway (registrar a transacao)

            return string.Empty;
        }
        //internal string RegistrarVenda(VendedorDAO vendedorDAO, List<ProdutoDAO> produtoListDAO, IDatabaseClient databaseClient)
        //{
        //    // quem chama esta passando apenas os dados!
        //    IVendedorGateway vendedorGateway = new VendedorGateway(databaseClient);
        //    IVendaGateway vendaGateway = new VendaGateway(databaseClient);
        //    IProdutoGateway produtoGateway = new ProdutoGateway(databaseClient);

        //    var vendedor = vendedorGateway.ObterPorIdentificacao(identificacao: vendedorDAO.Identificacao);
        //    List<ProdutoEntity> produtosVenda = new List<ProdutoEntity>();

        //    foreach (ProdutoDAO produtoDAO in produtoListDAO)
        //    {
        //        var produto = produtoGateway.ObterPorIdentificacao(produtoDAO.Identificacao);

        //        if (produtoDAO.Desconto != null)
        //            produto.DefinirDesconto(produtoDAO.Desconto.Value);
        //        produtosVenda.Add(produto);
        //    }

        //    var registrarVendaUseCase = new RegistrarVendaUseCase(vendedor, produtosVenda);
        //    var venda = registrarVendaUseCase.FinalizarVenda();
        //    vendaGateway.RegistrarVenda(venda);

        //    return VendaAdapter.ToJson(venda);
        //}

    }
}
