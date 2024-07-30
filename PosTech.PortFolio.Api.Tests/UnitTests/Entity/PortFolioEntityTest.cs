using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.Tests.UnitTests.Entity
{
    [Collection(nameof(PortFolioTestFixtureCollection))]
    public class PortFolioEntityTest
    {
        private readonly PortFolioTestFixture _fixture;

        public PortFolioEntityTest(PortFolioTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste unitario de validacao de PortFolio")]
        [Trait("Entity.PortFolio", "Teste unitario de validacao de PortFolio")]
        public void ValidateEntity_Should_New_PortFolioEntity()
        {
            //Arrange
            var entidade = _fixture.GerarPortFolioEntity();

            //Act
            var act = entidade != null;

            //Assert
            Assert.True(act);
            Assert.Equal(typeof(PortFolioEntity), entidade?.GetType());
        }
    }
}
