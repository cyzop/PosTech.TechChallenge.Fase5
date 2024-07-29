using Bogus;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Entity.Tests.Fixtures
{
    public class ClienteTestFixture
    {
        private readonly Faker _faker;

        public ClienteTestFixture()
        {
            _faker = new Faker();
        }
        public ClienteEntity GerarClienteEntity(string email)
        {
            var id = Guid.NewGuid().ToString();
            var nome = _faker.Person.FullName;
            var data = _faker.Date.Recent(10, DateTime.Now);

            return GetEntity(id, nome, email, data);
        }
        public ClienteEntity GerarClienteEntity()
        {
            var email = _faker.Person.Email;
            return GerarClienteEntity(email);
        }
        private ClienteEntity GetEntity(string id, string nome, string email, DateTime data)
        {
            return new ClienteEntity(nome, email, id, data);
        }

        public UsuarioDao GerarUsuarioDao()
        {
            var id = Guid.NewGuid().ToString();
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var data = _faker.Date.Recent(10, DateTime.Now);

            return new UsuarioDao(nome, email, id, data);
        }

       
    }
}
