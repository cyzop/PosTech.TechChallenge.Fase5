using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Postech.PortFolio.Ativo.Api.Controllers;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.Tests.UnitTests.API
{
    [Collection(nameof(AtivoTestFixtureCollection))]
    public class AtivoControllerApiTest
    {
        private readonly Mock<ILogger<AtivoController>> _loggerMock;
        private readonly Mock<IAtivoController> _ativoController;
        private readonly Mock<IAtivoGateway> _ativoGateway;
        private readonly AtivoTestFixture _fixture;
        private readonly AtivoController _controller;

        public AtivoControllerApiTest(AtivoTestFixture fixture)
        {
            _loggerMock = new Mock<ILogger<AtivoController>>();
            _ativoController = new Mock<IAtivoController>();
            _ativoGateway = new Mock<IAtivoGateway>();
            _fixture = fixture;

            _controller = new AtivoController(_loggerMock.Object, _ativoController.Object);
        }


        [Fact(DisplayName = "Teste unitario de validacao de ativo")]
        [Trait("Api.AtivoController", "Teste unitario de validacao de listagem de ativos")]
        public async void Get_ReturnsOkResultWithData()
        {
            var ativos = new List<AtivoDao> {
                _fixture.GerarAtivoDao(),
                _fixture.GerarAtivoDao()
            };

            _ativoController.Setup(ctr => ctr.ListarDisponiveis()).Returns(ativos);

            var ativosEntity = new List<AtivoEntity>()
            {
                _fixture.GerarAtivoEntity(),
                _fixture.GerarAtivoEntity()
            };

            _ativoGateway.Setup(gtw => gtw.ObterTodos()).Returns(ativosEntity);

            //Act
            var result = await _controller.GetAtivos();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(ativos, okResult.Value);
        }
    }
}