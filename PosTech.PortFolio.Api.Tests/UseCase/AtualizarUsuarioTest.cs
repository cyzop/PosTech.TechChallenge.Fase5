using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Entity.Tests.Fixtures;
using PosTech.PortFolio.UseCases;

namespace PosTech.PortFolio.Tests.UseCase
{
    [Collection(nameof(ClienteTestFixtureCollection))]
    public class AtualizarUsuarioTest
    {
        private readonly ClienteTestFixture _fixture;

        public AtualizarUsuarioTest(ClienteTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste de validacao da regra para Atualizar Usuário")]
        [Trait("UseCase.Cliente", "Teste de validação da atualização de um Usuário")]
        public async void ValidateUseCase_Should_NotException_VerifyMethod()
        {
            //Arrange
            var usuario = _fixture.GerarClienteEntity();
            var usuarioAlterar = (usuario);
            usuarioAlterar.Nome = "novonome";

            //Act
            var useCase = new AtualizarUsuarioUseCase(usuarioAlterar, usuario);
            var resultado = useCase.VerificarExistente();
            
            //Assert
            Assert.Equal(true, resultado!=null);
            Assert.Equal(resultado.GetType(), typeof(ClienteEntity));
            Assert.Equal(resultado.Nome, usuarioAlterar.Nome);
        }
    }
}
