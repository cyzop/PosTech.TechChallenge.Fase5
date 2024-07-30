using Bogus;
using PosTech.PortFolio.Controllers;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.DatabaseTest;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Gateways;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;
using PosTech.PortFolio.Messages.Ativo;
using PosTech.PortFolio.Repository.Sql.Interface;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.IntegratedTests.Controller
{
    public class TransacaoControllerIntegrationTest
    {
        private readonly Faker _faker;
        private readonly ITransacaoController _controller;
        private readonly IPortFolioController _portFolioController;

        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IAtivoRepository _ativoRepository;
        private readonly IPortFolioRepository _portFolioRepository;
        private readonly IClienteRepository _usuarioRepository;

        private readonly ITransacaoGateway _transacaoGateway;
        private readonly IAtivoGateway _ativoGateway;
        private readonly IUsuarioGateway _usuarioGateway;
        private readonly IPortFolioGateway _portFolioGateway;

        public TransacaoControllerIntegrationTest()
        {
            _faker = new Faker();
            
            _usuarioRepository = new ClienteDatabaseMock();
            _portFolioRepository = new PortfolioDatabaseMock(_usuarioRepository);
            _ativoRepository = new AtivoDatabaseMock();
            _transacaoRepository = new TransacaoDatabaseMock(_portFolioRepository, _ativoRepository);

            //gateway
            _transacaoGateway = new TransacaoGateway(_transacaoRepository);
            _ativoGateway = new AtivoGateway(_ativoRepository);
            _portFolioGateway = new PortFolioGateway(_portFolioRepository);
            _usuarioGateway = new UsuarioGateway(_usuarioRepository);

            //controller
            _controller = new TransacaoController(_ativoGateway, _portFolioGateway, _transacaoGateway);
            _portFolioController = new PortFolioController(_portFolioGateway, _usuarioGateway);
        }

        [Fact(DisplayName = "Validando NÃO inclusão de Transação Venda sem saldo no Ativo")]
        [Trait("Integrated.TransacaoController", "Validando NÃO inclusão de Transação Venda sem saldo no Ativo")]
        public async void Create_ShouldThrowException_WhenNoBalace()
        {
            //Arrange
            var transacoes = _controller.ListarTodos().ToList();
            var transacaoEspelho = transacoes[_faker.Random.Number(transacoes.Count - 1)];
            var ativoEspelho = transacaoEspelho.AtivoTransacao;
            var portFolioEspelho = transacaoEspelho.PortFolio;
            var clienteId = portFolioEspelho.Usuario.Id;

            var novaNegociacaoAtivo = new TransacaoTestFixture().GerarAtivoTransacaoDao(ativoEspelho, ativoEspelho.Quantidade + 10);

            //Act
            var result = Assert.Throws<ArgumentException>(() => _controller.RegistrarVenda(portFolioEspelho, novaNegociacaoAtivo));

            //Assert
            Assert.Equal(ValidationMessages.MensagemSaldoAtivoInsuficiente, result.Message);
        }

        [Fact(DisplayName = "Validando inclusão de Transação Compra de Ativo")]
        [Trait("Integrated.TransacaoController", "Validando inclusão de Transação Compra de Ativo")]
        public async void Create_Should_TransactionSucessReturnEntity()
        {
            //Arrange
            var transacoes = _controller.ListarTodos().ToList();
            var transacaoEspelho = transacoes[_faker.Random.Number(transacoes.Count - 1)];
            var ativoEspelho = transacaoEspelho.AtivoTransacao;
            var portFolioEspelho = transacaoEspelho.PortFolio;
            var clienteId = portFolioEspelho.Usuario.Id;

            var novaNegociacaoAtivo = new TransacaoTestFixture().GerarAtivoTransacaoDao(ativoEspelho, 10);
            //Act
            var transacaoDao = _controller.RegistrarCompra(portFolioEspelho, novaNegociacaoAtivo);

            //Assert
            Assert.Equal(typeof(TransacaoDao), transacaoDao?.GetType());
            Assert.True(transacaoDao.TipoTransacao == TipoTransacao.Compra.ToString());
            Assert.True(transacaoDao.AtivoTransacao.Codigo == novaNegociacaoAtivo.Codigo);
            Assert.True(transacaoDao.PortFolio.Id == portFolioEspelho.Id);
                
        }
    }
}
