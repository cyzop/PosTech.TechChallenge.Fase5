using Bogus;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.Ativo;
using PosTech.PortFolio.Tests.Fixtures;
using PosTech.PortFolio.UseCases.Transacao;

namespace PosTech.PortFolio.Tests.UnitTests.UseCase
{
    [Collection(nameof(TransacaoTestFixtureCollection))]
    public class RegistrarTransacaoCompraTest
    {
        private readonly TransacaoTestFixture _fixture;
        private readonly Faker _faker;

        public RegistrarTransacaoCompraTest(TransacaoTestFixture fixture)
        {
            _fixture = fixture;
            _faker = new Faker();
        }

        [Fact(DisplayName = "Teste de validacao da quantidade para Transação de Compra")]
        [Trait("UseCase.TransacaoCompra", "Teste de validação de quantidade para transação de compra")]
        public void ValidateUseCase_Should_AssertException_VerifyMethod()
        {
            //Arrange
            var portfolio = new PortFolioTestFixture().GerarPortFolioEntity();
            var ativo = new AtivoTestFixture().GerarAtivoEntity();

            var quantidade = 0;
            var preco = _faker.Random.Double(1);

            //Act
            var useCase = new RegistrarTransacaoCompraUseCase(portfolio, ativo, quantidade, preco);

            //Assert
            var result = Assert.Throws<ArgumentException>(() => useCase.FinalizarTransacao());
            Assert.Equal(ValidationMessages.MensagemQuantidadeAtivosInvalida, result.Message);
            Assert.True(quantidade == 0);
        }

        [Fact(DisplayName = "Teste de validacao da Transação de Compra")]
        [Trait("UseCase.TransacaoCompra", "Teste de validação da transação de compra")]
        public void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var portfolio = new PortFolioTestFixture().GerarPortFolioEntity();
            var ativo = new AtivoTestFixture().GerarAtivoEntity();

            var quantidade = _faker.Random.Number(1, 100);
            var preco = _faker.Random.Double(1, 100);

            //Act
            var useCase = new RegistrarTransacaoCompraUseCase(portfolio, ativo, quantidade, preco);

            var verifyAssertException = false;
            try
            {
                var resultado = useCase.FinalizarTransacao();
                //Assert
                Assert.Equal(typeof(TransacaoEntity), resultado.GetType());
                Assert.Equal(resultado.Quantidade, quantidade);
                Assert.Equal(resultado.Preco, preco);
                Assert.Equal(resultado.PortFolio, portfolio);
                Assert.Equal(resultado.Ativo, ativo);
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
