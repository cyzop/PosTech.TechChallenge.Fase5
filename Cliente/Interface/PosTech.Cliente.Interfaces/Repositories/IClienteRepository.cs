using PostTech.Cliente.Entities;

namespace PosTech.Cliente.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void AtualizarUsuario(UsuarioEntity usuario);
        UsuarioEntity IncluirUsuario(UsuarioEntity usuario);
        UsuarioEntity ObterPorId(string id);
        UsuarioEntity ObterPorEmail(string email);
        IEnumerable<UsuarioEntity> ObterUsuarios();
    }
}
