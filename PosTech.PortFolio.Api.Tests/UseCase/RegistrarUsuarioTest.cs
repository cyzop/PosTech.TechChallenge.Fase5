using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Entity.Tests.Fixtures;
using PosTech.PortFolio.UseCases;

namespace PosTech.PortFolio.Tests.UseCase
{
    [Collection(nameof(ClienteTestFixtureCollection))]
    public class RegistrarUsuarioTest
    {
        private readonly ClienteTestFixture _fixture;

        public RegistrarUsuarioTest(ClienteTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste de validacao da regra para não Incluir Usuário com mesmo Email")]
        [Trait("UseCase.Cliente", "Teste de validação da NÃO inclusão de um Usuário com mesmo email de outro")]
        public async void ValidateUseCase_Should_UniqueEmail_VerifyMethod()
        {
            //Arrange
            var usuarioNovo = _fixture.GerarClienteEntity();
            var usuarioMesmoEmail = _fixture.GerarClienteEntity(usuarioNovo.Email);

            //Act
            var useCase = new RegistrarUsuarioUseCase(usuarioNovo, usuarioMesmoEmail);

            var verifyAssertException = false;
            try
            {
                var resultado = useCase.VerificarNovo();
            }
            catch (ArgumentException assertException)
            {
                verifyAssertException = true;
            }

            //Assert
            Assert.Equal(true, verifyAssertException);
            Assert.Equal(usuarioNovo.Email, usuarioMesmoEmail.Email);
        }
    }
}
