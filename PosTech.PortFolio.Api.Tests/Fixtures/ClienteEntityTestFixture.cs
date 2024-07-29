using Bogus;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Entity.Tests.Fixtures
{
    public class ClienteEntityTestFixture
    {
        private readonly Faker _faker;

        public ClienteEntityTestFixture()
        {
            _faker = new Faker();
        }

        public ClienteEntity GerarClienteEntity()
        {
            var id = Guid.NewGuid().ToString();
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var data = _faker.Date.Recent(10, DateTime.Now);

            return new ClienteEntity(nome, email, id, data);
        }
    }
}
