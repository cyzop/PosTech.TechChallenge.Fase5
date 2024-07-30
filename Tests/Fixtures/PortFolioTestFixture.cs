using Bogus;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Tests.Fixtures
{
    public class PortFolioTestFixture
    {
        private readonly Faker _faker;

        public PortFolioTestFixture()
        {
            _faker = new Faker();
        }
        public PortFolioEntity GerarPortFolioEntity(string nome)
        {
            return GetEntity(nome);
        }
        public PortFolioEntity GerarPortFolioEntity()
        {
            var nome = _faker.Person.FullName;
            return GetEntity(nome);
        }

        private PortFolioEntity GetEntity(string nome)
        {
            var id = Guid.NewGuid().ToString();
            var descricao = _faker.Lorem.Text();
            var data = _faker.Date.Recent(10, DateTime.Now);

            var cliente = new ClienteTestFixture().GerarClienteEntity();
            return new PortFolioEntity(cliente, nome, descricao, id, data);
        }

        private PortFolioDao GetPortFolioDao(string nome, string clientId)
        {
            var id = Guid.NewGuid().ToString();
            
            var descricao = _faker.Lorem.Text();
            var data = _faker.Date.Recent(10, DateTime.Now);

            var cliente = new ClienteTestFixture().GerarUsuarioDao(clientId);

            return new PortFolioDao()
            {
                Id = id,
                Nome = nome,
                DataCriacao = data,
                Descricao = descricao,
                Usuario = cliente
            };
        }
        public PortFolioDao GerarPortFolioDao() {
            var nome = _faker.Person.FullName;
            return GetPortFolioDao(nome, string.Empty);
        }
        public PortFolioDao GerarPortFolioDao(string nome, string clientId)
        {
            return GetPortFolioDao(nome, clientId);
        }
        public PortFolioDao GerarPortFolioDao(string nome)
        {
            return GetPortFolioDao(nome, string.Empty);
        }
    }
}
