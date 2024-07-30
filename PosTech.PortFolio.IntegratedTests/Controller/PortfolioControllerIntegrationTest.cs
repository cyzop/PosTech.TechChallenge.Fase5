using Bogus;
using NuGet.Frameworks;
using PosTech.PortFolio.Controllers;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Gateways;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;
using PosTech.PortFolio.Messages.PortFolio;
using PosTech.PortFolio.Tests;
using PosTech.PortFolio.Tests.Fixtures;
using Xunit;

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

        public PortfolioControllerIntegrationTest(Faker faker)
        {
            _faker = faker;
            _portfolioRepository = new DatabaseTest().GetPortfolioRepository();

            _portfolioGateway = new PortFolioGateway(_portfolioRepository);
            _usuarioGateway = new UsuarioGateway(_usuarioRepository);

            _controller = new PortFolioController(_portfolioGateway, _usuarioGateway);
        }

        [Fact(DisplayName = "Validando NÃO inclusão de PortFolio nome já existente")]
        [Trait("Integrated.PortfolioController", "Validando NÃO inclusão de PortFolio nome já existente")]
        public void Create_ShouldThrowException_WhenNameIsDuplicated()
        {
            //Arrange
            var portFolios = _controller.ListarTodos().ToList();
            var nome = portFolios[_faker.Random.Number(portFolios.Count - 1)].Nome;

            var novoPortofolioMesmoNome = new PortFolioTestFixture().GerarPortFolioDao(nome);

            //Act
            var result = Assert.Throws<Exception>(() => _controller.RegistrarPortFolio(novoPortofolioMesmoNome));

            //Assert
            Assert.Equal(ValidationMessages.MensagemPortFolioJaExistente, result.Message);
        }

        [Fact(DisplayName = "Validando Lisagem de portfolios de um CLiente")]
        [Trait("Integrated.PortfolioController", "Validando Lisagem de portfolios de um CLiente")]
        public void Create_Should_ReturnPortfolioList()
        {
            //Arrange
            var portFolios = _controller.ListarTodos().ToList();
            var clienteId = portFolios[_faker.Random.Number(portFolios.Count - 1)].Usuario.Id;

            //Act
            var portFoliosCliente = _controller.ListarPorUsuario(clienteId);

            //Assert
            Assert.All<PortFolioDao>(portFoliosCliente, item => Assert.Equal(item.Usuario.Id, clienteId));
        }
    }
}
