using PosTech.PortFolio.Api.Tests.fixtures;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Tests.Entity
{
    [Collection(nameof(AtivoTestFixtureCollection))]
    public class AtivoEntityTest
    {
        private readonly AtivoTestFixture _fixture;

        public AtivoEntityTest(AtivoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste unitario de validacao de Ativo")]
        [Trait("Entity.Ativo", "Teste unitario de validacao de Ativo")]
        public async void ValidateEntity_Should_New_AtivoEntity()
        {
            //Arrange
            var entidade = _fixture.GerarAtivoEntity();

            //Act
            var act = entidade != null;

            //Assert
            Assert.Equal(true, act);
            Assert.Equal(entidade.GetType(), typeof(AtivoEntity));
        }
    }
}
