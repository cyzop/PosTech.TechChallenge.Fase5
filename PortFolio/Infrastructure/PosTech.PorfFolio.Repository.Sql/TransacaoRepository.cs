using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Repository.Sql.Interface;

namespace PosTech.PortFolio.Repository.Sql
{
    public class TransacaoRepository : EFRepository<TransacaoEntity>, ITransacaoRepository
    {
        public TransacaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<TransacaoEntity> ConsultarPorPortFolio(string portFolioId)
        {
            return _context.Transacao.Where(t => t.PortFolioId == portFolioId).ToList();
        }
    }
}
