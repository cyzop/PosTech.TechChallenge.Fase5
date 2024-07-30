using Bogus;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.Ativo;
using PosTech.PortFolio.Tests.Fixtures;
using PosTech.PortFolio.UseCases.Transacao;

namespace PosTech.PortFolio.Tests.UnitTests.UseCase
{
    [Collection(nameof(TransacaoTestFixtureCollection))]
    public class RegistrarTransacaoVendaTest
    {
        private readonly TransacaoTestFixture _fixture;
        private readonly Faker _faker;

        public RegistrarTransacaoVendaTest(TransacaoTestFixture fixture)
        {
            _fixture = fixture;
            _faker = new Faker();
        }

        [Fact(DisplayName = "Teste de validacao da quantidade para Transação de Venda")]
        [Trait("UseCase.TransacaoVenda", "Teste de validação de quantidade para transação de Venda")]
        public void ValidateUseCase_Should_AssertException_VerifyMethod()
        {
            //Arrange
            var portfolio = new PortFolioTestFixture().GerarPortFolioEntity();
            var ativo = new AtivoTestFixture().GerarAtivoEntity();
            var saldoNoAtivo = new InvestimentoEntity(ativo, _faker.Random.Number(10));

            var quantidade = _faker.Random.Number(11, 100);//menor que a quantidade existente
            var preco = _faker.Random.Double(1);

            //Act
            var useCase = new RegistrarTransacaoVendaUseCase(portfolio, ativo, quantidade, preco, saldoNoAtivo);

            //Assert
            var result = Assert.Throws<ArgumentException>(() => useCase.FinalizarTransacao());
            Assert.Equal(ValidationMessages.MensagemSaldoAtivoInsuficiente, result.Message);
            Assert.True(quantidade > saldoNoAtivo.Quantidade);
        }

        [Fact(DisplayName = "Teste de validacao da Transação de Venda")]
        [Trait("UseCase.TransacaoVenda", "Teste de validação da transação de Venda")]
        public void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var portfolio = new PortFolioTestFixture().GerarPortFolioEntity();
            var ativo = new AtivoTestFixture().GerarAtivoEntity();
            var saldoNoAtivo = new InvestimentoEntity(ativo, _faker.Random.Number(10));

            var quantidade = _faker.Random.Number(1, 10);
            var preco = _faker.Random.Double(1, 100);

            //Act
            var useCase = new RegistrarTransacaoVendaUseCase(portfolio, ativo, quantidade, preco, saldoNoAtivo);

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
            catch (ArgumentException ex)
            {
                verifyAssertException = true;
            }

            //Assert
            Assert.False(verifyAssertException);
        }
    }
}
