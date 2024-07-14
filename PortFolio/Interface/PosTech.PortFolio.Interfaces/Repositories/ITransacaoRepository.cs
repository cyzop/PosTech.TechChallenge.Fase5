using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Repository.Sql.Interface
{
    public interface ITransacaoRepository : IRepository<TransacaoEntity>
    {
        public IEnumerable<TransacaoEntity> ConsultarPorPortFolio(string portFolioId);
    }
}
