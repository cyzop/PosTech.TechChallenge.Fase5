using Bogus;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;
using PosTech.PortFolio.Repository.Sql.Interface;
using System.Collections.Immutable;

namespace PosTech.PortFolio.DatabaseTest
{
    public class TransacaoDatabaseMock : ITransacaoRepository
    {
        private readonly List<TransacaoEntity> _transacoes;
        private readonly Faker _faker;

        public TransacaoDatabaseMock(IPortFolioRepository portFolioRepository, IAtivoRepository ativoRepository)
        {
            _transacoes = new List<TransacaoEntity>(); ;
            _faker = new Faker();

            var portfolios = portFolioRepository.ConsultarTodos().ToList();
            var ativos = ativoRepository.ConsultarTodos().ToList();

            for (int i = 0; i < 10; i++)
                for (int j = 0; i < 2; i++)
                    _transacoes.Add(new(portfolios[i], ativos[j], (TipoTransacao)_faker.Random.Number(1), _faker.Random.Int(100), _faker.Random.Double(1, 100), Guid.NewGuid().ToString(), DateTime.Now));

        }

        public void Alterar(TransacaoEntity entity)
        {
            foreach (var transacao in _transacoes.Where(a => a.Id == entity.Id))
            {
                transacao.SetQuantidade(entity.Quantidade);
                transacao.SetPreco(entity.Preco);
            }
        }

        public IEnumerable<TransacaoEntity> ConsultarPorAtivoEPortFolio(string ativoId, string portFolioId)
        {
            return _transacoes.Where(a => a.Ativo.Id == ativoId && a.PortFolio.Id == portFolioId);
        }

        public TransacaoEntity ConsultarPorId(string id)
        {
            return _transacoes.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<TransacaoEntity> ConsultarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _transacoes.Where(a => a.DataCriacao >= inicio && a.DataCriacao <= fim).ToList();
        }

        public IEnumerable<TransacaoEntity> ConsultarPorPortFolio(string portFolioId)
        {
            return _transacoes.Where(a => a.PortFolio.Id == portFolioId);
        }

        public ICollection<TransacaoEntity> ConsultarTodos()
        {
            return _transacoes;
        }

        public void Incluir(TransacaoEntity entity)
        {
            _transacoes.Add(entity);
        }

        public void Remover(string id)
        {
            var item = _transacoes.FirstOrDefault(a => a.Id == id);
            if (item != null)
                _transacoes.Remove(item);
        }
    }
}
