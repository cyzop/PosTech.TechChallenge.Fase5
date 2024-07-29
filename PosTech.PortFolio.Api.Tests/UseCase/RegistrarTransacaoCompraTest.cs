using Bogus;
using PosTech.PortFolio.Api.Tests.fixtures;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Tests.Fixtures;
using PosTech.PortFolio.UseCases.Transacao;

namespace PosTech.PortFolio.Tests.UseCase
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
        public async void ValidateUseCase_Should_AssertException_VerifyMethod()
        {
            //Arrange
            var portfolio = new PortFolioTestFixture().GerarPortFolioEntity();
            var ativo = new AtivoTestFixture().GerarAtivoEntity();

            var quantidade = 0;
            var preco = _faker.Random.Double(1);

            //Act
            var useCase = new RegistrarTransacaoCompraUseCase(portfolio, ativo, quantidade, preco);

            var verifyAssertException = false;
            try
            {
                var resultado = useCase.FinalizarTransacao();
            }
            catch (ArgumentException assertException)
            {
                verifyAssertException = true;
            }

            //Assert
            Assert.Equal(true, verifyAssertException);
        }

        [Fact(DisplayName = "Teste de validacao da Transação de Compra")]
        [Trait("UseCase.TransacaoCompra", "Teste de validação da transação de compra")]
        public async void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var portfolio = new PortFolioTestFixture().GerarPortFolioEntity();
            var ativo = new AtivoTestFixture().GerarAtivoEntity();

            var quantidade = _faker.Random.Number(1,100);
            var preco = _faker.Random.Double(1, 100);

            //Act
            var useCase = new RegistrarTransacaoCompraUseCase(portfolio, ativo, quantidade, preco);

            var verifyAssertException = false;
            try
            {
                var resultado = useCase.FinalizarTransacao();
                //Assert
                Assert.Equal(resultado.GetType(), typeof(TransacaoEntity));
                Assert.Equal(resultado.Quantidade, quantidade);
                Assert.Equal(resultado.Preco, preco);
                Assert.Equal(resultado.PortFolio, portfolio);
                Assert.Equal(resultado.Ativo, ativo);
            }
            catch (ArgumentException assertException)
            {
                verifyAssertException = true;
            }

            //Assert
            Assert.Equal(false, verifyAssertException);
        }
    }
}
