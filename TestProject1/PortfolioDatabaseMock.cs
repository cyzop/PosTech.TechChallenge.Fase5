using Bogus;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.DatabaseTest
{
    public class PortfolioDatabaseMock : IPortFolioRepository
    {
        private readonly List<PortFolioEntity> _portfolios;
        private readonly Faker _faker;
        private readonly List<ClienteEntity> clientes;

        public PortfolioDatabaseMock(IClienteRepository clientRepository)
        {
            _portfolios = new List<PortFolioEntity>();
            _faker = new Faker();

            clientes = clientRepository.ConsultarTodos().ToList();

            //Portfolio
            var portfolios = new List<PortFolioEntity>();
            for (int i = 0; i < 10; i++)
                _portfolios.Add(new(clientes[i], _faker.Person.FullName, _faker.Lorem.Text(), Guid.NewGuid().ToString(), DateTime.Now));
            
        }

        public void Alterar(PortFolioEntity entity)
        {
            foreach (var portfolio in _portfolios.Where(a => a.Id == entity.Id))
            {
                portfolio.Nome = entity.Nome;
                portfolio.Descricao = entity.Descricao;
            }
        }

        public PortFolioEntity Atualizar(PortFolioEntity entity)
        {
            Alterar(entity);
            return entity;
        }

        public PortFolioEntity ConsultarPorId(string id)
        {
            return _portfolios.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<PortFolioEntity> ConsultarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _portfolios.Where(a => a.DataCriacao >= inicio && a.DataCriacao <= fim).ToList();
        }

        public IEnumerable<PortFolioEntity> ConsultarPorUsuario(string usuarioId)
        {
            return _portfolios.Where(a => a.Cliente.Id == usuarioId);
        }

        public ICollection<PortFolioEntity> ConsultarTodos()
        {
            return _portfolios;
        }

        public void Incluir(PortFolioEntity entity)
        {
            _portfolios.Add(entity);
        }

        public void Remover(string id)
        {
            var item = _portfolios.FirstOrDefault(a => a.Id == id);
            if (item != null)
                _portfolios.Remove(item);
        }
    }
}
