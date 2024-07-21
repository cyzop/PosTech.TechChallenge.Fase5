using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Entity.Tests.Fixtures;

namespace PosTech.PortFolio.Entity.Tests
{
    [Collection(nameof(ClienteEntityTextFixtureCollection))]
    public class ClienteEntityTest
    {
        private readonly ClienteEntityTextFixture _fixture;
        public ClienteEntityTest(ClienteEntityTextFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste unitario de validacao de Cliente")]
        [Trait("Entity.Cliente", "Teste unitario de validacao de cliente")]
        public async void ValidateEntity_Should_New_ClienteEntity()
        {
            //Arrange
            var entidade = _fixture.GerarClienteEntity();

            //Act
            var act = entidade != null;

            //Assert
            Assert.Equal(true, act);
            Assert.Equal(entidade.GetType(), typeof(ClienteEntity));
        }
    }
}
