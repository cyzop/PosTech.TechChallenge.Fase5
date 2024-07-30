using Bogus;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.DatabaseTest
{
    public class ClienteDatabaseMock : IClienteRepository
    {
        private readonly List<ClienteEntity> _clientes;
        private readonly Faker _faker;

        public ClienteDatabaseMock()
        {
            _clientes = new List<ClienteEntity>();
            _faker = new Faker();

            for (int i = 0; i < 10; i++)
                _clientes.Add(new($"{i}{_faker.Lorem.Word()}", $"{_faker.Internet.Email()}", Guid.NewGuid().ToString(), DateTime.Now));

        }

        public void Alterar(ClienteEntity entity)
        {
            foreach (var portfolio in _clientes.Where(a => a.Id == entity.Id))
            {
                portfolio.Nome = entity.Nome;
                portfolio.Email = entity.Email;
            }
        }

        public ClienteEntity Atualizar(ClienteEntity entity)
        {
            Alterar(entity);
            return entity;
        }

        public ClienteEntity ConsultarPorEmail(string email)
        {
            return _clientes.FirstOrDefault(a => a.Email == email);
        }

        public ClienteEntity ConsultarPorId(string id)
        {
            return _clientes.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<ClienteEntity> ConsultarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _clientes.Where(a => a.DataCriacao >= inicio && a.DataCriacao <= fim).ToList();
        }

        public ICollection<ClienteEntity> ConsultarTodos()
        {
            return _clientes;
        }

        public void Incluir(ClienteEntity entity)
        {
            _clientes.Add(entity);
        }
              
        public void Remover(string id)
        {
            var item = _clientes.FirstOrDefault(a => a.Id == id);
            if (item != null)
                _clientes.Remove(item);
        }
    }
}
