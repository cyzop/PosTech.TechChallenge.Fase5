using Bogus;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Tests.Fixtures
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
        private static ClienteEntity GetEntity(string id, string nome, string email, DateTime data)
        {
            return new ClienteEntity(nome, email, id, data);
        }

        public UsuarioDao GerarUsuarioDao(string clientId)
        {
            return GetUsuarioDao(clientId);
        }
        public UsuarioDao GerarUsuarioDao()
        {
            return GetUsuarioDao(string.Empty);
        }
        private UsuarioDao GetUsuarioDao(string clientId)
        {
            var id = string.IsNullOrEmpty(clientId) ? Guid.NewGuid().ToString() : clientId;
            var nome = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var data = _faker.Date.Recent(10, DateTime.Now);

            return new UsuarioDao(id, nome, email, data);
        }

       
    }
}
