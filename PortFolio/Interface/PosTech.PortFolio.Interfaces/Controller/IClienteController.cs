using PosTech.PortFolio.DAO;

namespace PosTech.PortFolio.Interfaces.Controller
{
    public interface IClienteController
    {
        UsuarioDao IncluirUsuario(NovoUsuarioDao usuario);
        UsuarioDao AtualizarUsuario(NovoUsuarioDao usuario);
        UsuarioDao ObterUsuarioPorEmail(string email);
        UsuarioDao ObterUsuarioPorId(string id);
        IEnumerable<UsuarioDao> ListarUsuarios();
    }
}
