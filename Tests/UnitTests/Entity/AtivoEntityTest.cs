using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.Tests.UnitTests.Entity
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
        public void ValidateEntity_Should_New_AtivoEntity()
        {
            //Arrange
            var entidade = _fixture.GerarAtivoEntity();

            //Act
            var act = entidade != null;

            //Assert
            Assert.True(act);
            Assert.Equal(typeof(AtivoEntity), entidade?.GetType());
        }
    }
}
