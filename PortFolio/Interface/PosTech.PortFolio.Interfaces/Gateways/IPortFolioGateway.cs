using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface IPortFolioGateway
    {
        public PortFolioEntity ObterPorId(string id);
        IEnumerable<PortFolioEntity> ObterPorUsuario(string usuarioId);
        IEnumerable<PortFolioEntity> ObterTodos();
        void RegistrarPortFolio(PortFolioEntity portFolio);
    }
}
