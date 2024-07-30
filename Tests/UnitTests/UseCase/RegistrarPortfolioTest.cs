using Microsoft.AspNetCore.Mvc;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.PortFolio;
using PosTech.PortFolio.Tests.Fixtures;
using PosTech.PortFolio.UseCases.PortFolio;

namespace PosTech.PortFolio.Tests.UnitTests.UseCase
{
    [Collection(nameof(PortFolioTestFixtureCollection))]
    public class RegistrarPortfolioTest
    {
        private readonly PortFolioTestFixture _fixture;

        public RegistrarPortfolioTest(PortFolioTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste de validacao da criação de um novo Portfólio")]
        [Trait("UseCase.Portfólio", "Teste de validação de NÃO criação de um novo Portfólio cujo nome já existe")]
        public void ValidateUseCase_Should_AssertException_VerifyMethod()
        {
            //Arrange            
            var portfoliosUsuario = new List<PortFolioEntity>
            {
                 new PortFolioTestFixture().GerarPortFolioEntity(),
                 new PortFolioTestFixture().GerarPortFolioEntity(),
                 new PortFolioTestFixture().GerarPortFolioEntity()
            };
            var novoPortfolioMesmoNome = new PortFolioTestFixture().GerarPortFolioEntity(portfoliosUsuario[0].Nome);

            //Act
            var useCase = new RegistrarPortFolioUseCase(novoPortfolioMesmoNome, portfoliosUsuario);


            //Act
            var result = Assert.Throws<ArgumentException>(() => useCase.VerificarPortFolio());

            //Assert
            Assert.Equal(ValidationMessages.MensagemPortFolioJaExistente, result.Message);
        }

        [Fact(DisplayName = "Teste de validacao da criação de um novo Portfólio com nome invalido")]
        [Trait("UseCase.Portfólio", "Teste de validação de criação de um novo Portfólio")]
        public void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            //Arrange            
            var portfoliosUsuario = new List<PortFolioEntity>
            {
                 new PortFolioTestFixture().GerarPortFolioEntity(),
                 new PortFolioTestFixture().GerarPortFolioEntity(),
                 new PortFolioTestFixture().GerarPortFolioEntity()
            };
            var novoPortfolio = new PortFolioTestFixture().GerarPortFolioEntity();

            //Act
            var useCase = new RegistrarPortFolioUseCase(novoPortfolio, portfoliosUsuario);

            var verifyAssertException = false;
            try
            {
                var resultado = useCase.VerificarPortFolio();
                //Assert
                Assert.Equal(typeof(PortFolioEntity), resultado.GetType());
                Assert.Equal(novoPortfolio.Nome, resultado.Nome);
                Assert.Equal(novoPortfolio.Cliente.Id, resultado.Cliente.Id);
            }
            catch (ArgumentException)
            {
                verifyAssertException = true;
            }

            //Assert
            Assert.False(verifyAssertException);
        }
    }
}
