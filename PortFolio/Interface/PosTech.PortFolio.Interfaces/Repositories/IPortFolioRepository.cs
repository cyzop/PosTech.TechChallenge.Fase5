using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Repositories
{
    public interface IPortFolioRepository : IRepository<PortFolioEntity>
    {
        IEnumerable<PortFolioEntity> ConsultarPorUsuario(string usuarioId);
    }
    
}
