using Bogus;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Entity.Tests.Fixtures;

namespace PosTech.PortFolio.Tests.Fixtures
{
    public class PortFolioEntityTestFixture
    {
        private readonly Faker _faker;

        public PortFolioEntityTestFixture()
        {
            _faker = new Faker();
        }
        public PortFolioEntity GerarPortFolioEntity()
        {
            var id = Guid.NewGuid().ToString();
            var nome = _faker.Person.FullName;
            var descricao = _faker.Lorem.Text();
            var data = _faker.Date.Recent(10, DateTime.Now);

            var cliente = new ClienteEntityTestFixture().GerarClienteEntity();

            return new PortFolioEntity(cliente, nome, descricao, id, data);
        }

    }
}
