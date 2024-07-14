using PosTech.Cliente.Entities;

namespace PosTech.Cliente.Interfaces.Gateways
{
    public interface IClienteGateway
    {
        UsuarioEntity ObterPorEmail(string email);
        UsuarioEntity ObterPorId(string id);
        IEnumerable<UsuarioEntity> ObterUsuarios();
        UsuarioEntity RegistrarUsuario(UsuarioEntity novoUsuario);
    }
}
