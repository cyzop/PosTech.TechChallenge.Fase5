
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface IUsuarioGateway
    {
        ClienteEntity ObterPorEmail(string email);
        ClienteEntity ObterPorId(string id);
        void RegistrarUsuario(ClienteEntity novoUsuario);
        IEnumerable<ClienteEntity> ObterUsuarios();
    }
}
