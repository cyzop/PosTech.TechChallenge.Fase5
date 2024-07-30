using Bogus;
using PosTech.PortFolio.Controllers;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.DatabaseTest;
using PosTech.PortFolio.Gateways;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;
using PosTech.PortFolio.Messages.PortFolio;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.IntegratedTests.Controller
{
    public class PortfolioControllerIntegrationTest
    {
        private readonly Faker _faker;
        private readonly IPortFolioController _controller;
        private readonly IPortFolioRepository _portfolioRepository;
        private readonly IClienteRepository _usuarioRepository;
        private readonly IPortFolioGateway _portfolioGateway;
        private readonly IUsuarioGateway _usuarioGateway;

        public PortfolioControllerIntegrationTest()
        {
            _faker = new Faker();
            _usuarioRepository = new ClienteDatabaseMock();
            _portfolioRepository = new PortfolioDatabaseMock(_usuarioRepository);
            
            //gateway
            _portfolioGateway = new PortFolioGateway(_portfolioRepository);
            _usuarioGateway = new UsuarioGateway(_usuarioRepository);
            //controller
            _controller = new PortFolioController(_portfolioGateway, _usuarioGateway);
        }

        [Fact(DisplayName = "Validando NÃO inclusão de PortFolio nome já existente")]
        [Trait("Integrated.PortfolioController", "Validando NÃO inclusão de PortFolio nome já existente")]
        public async void Create_ShouldThrowException_WhenNameIsDuplicated()
        {
            //Arrange
            var portFolios = _controller.ListarTodos().ToList();
            var portFolioEspelho = portFolios[_faker.Random.Number(portFolios.Count - 1)];
            var nome = portFolioEspelho.Nome;
            var clienteId = portFolioEspelho.Usuario.Id;

            var novoPortofolioMesmoNome = new PortFolioTestFixture().GerarPortFolioDao(nome, clienteId);

            //Act
            var result = Assert.Throws<ArgumentException>(() => _controller.RegistrarPortFolio(novoPortofolioMesmoNome));

            //Assert
            Assert.Equal(ValidationMessages.MensagemPortFolioJaExistente, result.Message);
        }

        [Fact(DisplayName = "Validando Lisagem de portfolios de um CLiente")]
        [Trait("Integrated.PortfolioController", "Validando Lisagem de portfolios de um CLiente")]
        public async void Create_Should_ReturnPortfolioList()
        {
            //Arrange
            var portFolios = _controller.ListarTodos().ToList();
            var userMail = portFolios[_faker.Random.Number(portFolios.Count - 1)].Usuario.Email;

            //Act
            var portFoliosCliente = _controller.ListarPorUsuario(userMail);

            //Assert
            Assert.All<PortFolioDao>(portFoliosCliente, item => Assert.Equal(item.Usuario.Email, userMail));
        }
    }
}
