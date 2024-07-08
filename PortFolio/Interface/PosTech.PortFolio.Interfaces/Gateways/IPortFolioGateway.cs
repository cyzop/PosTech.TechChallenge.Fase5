using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface IPortFolioGateway
    {
        PortFolioEntity ObterPorId(string id);
    }
}
