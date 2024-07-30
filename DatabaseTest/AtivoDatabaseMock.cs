using Bogus;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.DatabaseTest
{
    public class AtivoDatabaseMock : IAtivoRepository
    {
        private readonly List<AtivoEntity> _ativos;
        private readonly Faker _faker;
        public AtivoDatabaseMock()
        {
            _faker = new Faker();
            //Ativos
            _ativos = new List<AtivoEntity>();
            for (int i = 0; i < 10; i++)
                _ativos.Add(new((TipoAtivo)_faker.Random.Number(2), _faker.Finance.AccountName(), _faker.Finance.Bic(), Guid.NewGuid().ToString(), DateTime.Now));
        }
        public void Alterar(AtivoEntity entity)
        {
            foreach (var ativo in _ativos.Where(a=>a.Id == entity.Id)){
                ativo.Nome = entity.Nome;
                ativo.Codigo = entity.Codigo;
                ativo.Tipo = entity.Tipo;
            }
        }
        public AtivoEntity ConsultaPorCodigo(string codigo)
        {
            return _ativos.FirstOrDefault(a => a.Codigo == codigo);
        }

        public AtivoEntity ConsultarPorId(string id)
        {
            return _ativos.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<AtivoEntity> ConsultarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _ativos.Where(a=>a.DataCriacao >= inicio && a.DataCriacao <= fim).ToList();
        }

        public ICollection<AtivoEntity> ConsultarTodos()
        {
            return _ativos;
        }

        public void Incluir(AtivoEntity entity)
        {
            _ativos.Add(entity);
        }

        public void Remover(string id)
        {
            var item = _ativos.FirstOrDefault(a => a.Id == id);
            if (item != null)
                _ativos.Remove(item);
        }
    }
}
