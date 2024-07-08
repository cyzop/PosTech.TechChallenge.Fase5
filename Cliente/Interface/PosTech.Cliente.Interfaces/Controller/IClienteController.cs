using PosTech.Cliente.DAO;

namespace PosTech.Cliente.Interfaces.Controller
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
