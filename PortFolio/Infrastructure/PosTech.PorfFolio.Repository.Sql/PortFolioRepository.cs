using Microsoft.EntityFrameworkCore;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Repository.Sql
{
    public class PortFolioRepository : EFRepository<PortFolioEntity>, IPortFolioRepository
    {
        public PortFolioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<PortFolioEntity> ConsultarPorUsuario(string usuarioId)
        {
            return _context.PortFolio.Where( p=> p.ClienteId == usuarioId).ToList();
        }

        public PortFolioEntity Atualizar(PortFolioEntity entity)
        {
            _context.PortFolio.Update(entity);// .Where(p => p.Id == entity.Id).UpdateFromQuery() .ExecuteUpdate( u=> new PortFolioEntity() { Cliente = u.Cliente, })
            _context.SaveChanges();
            return entity;
        }
    }
}
