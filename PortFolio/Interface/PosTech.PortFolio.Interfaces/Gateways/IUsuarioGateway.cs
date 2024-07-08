
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface IUsuarioGateway
    {
        ClienteEntity ObterPorId(object id);
    }
}
