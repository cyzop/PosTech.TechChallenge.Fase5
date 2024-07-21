using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Entity.Tests.Fixtures;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.Tests.Entity
{
    [Collection(nameof(PortFolioEntityTestFixtureCollection))]
    public class PortFolioEntityTest
    {
        private readonly PortFolioEntityTestFixture _fixture;

        public PortFolioEntityTest(PortFolioEntityTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste unitario de validacao de PortFolio")]
        [Trait("Entity.PortFolio", "Teste unitario de validacao de PortFolio")]
        public async void ValidateEntity_Should_New_PortFolioEntity()
        {
            //Arrange
            var entidade = _fixture.GerarPortFolioEntity();

            //Act
            var act = entidade != null;

            //Assert
            Assert.Equal(true, act);
            Assert.Equal(entidade.GetType(), typeof(PortFolioEntity));
        }
    }
}
