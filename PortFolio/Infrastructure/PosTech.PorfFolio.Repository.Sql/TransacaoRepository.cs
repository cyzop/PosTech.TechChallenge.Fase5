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
            return _context.Transacao.Where(t => t.PortFolioId == portFolioId).OrderBy(p=>p.DataCriacao).ToList();
        }

        public IEnumerable<TransacaoEntity> ConsultarPorAtivoEPortFolio(string ativoId, string portFolioId)
        {
            return _context.Transacao.Where(t => t.PortFolioId == portFolioId && t.AtivoId == ativoId).ToList();
        }
    }
}
