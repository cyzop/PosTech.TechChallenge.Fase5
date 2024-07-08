using PostTech.Cliente.Entities;

namespace PosTech.Cliente.UseCases
{
    public class AtualizarUsuarioUseCase
    {
        private readonly UsuarioEntity _novoUsuario;
        private readonly UsuarioEntity _usuarioBase;

        public AtualizarUsuarioUseCase(UsuarioEntity novoUsuario, UsuarioEntity usuario)
        {
            _novoUsuario = novoUsuario;
            _usuarioBase = usuario;
        }
        public UsuarioEntity VerificarExistente()
        {
            if (_usuarioBase == null)
                throw new Exception("Usuário não localizado!");

            if (_novoUsuario.Email == _usuarioBase.Email 
                && _novoUsuario.Id != _usuarioBase.Id)
                throw new Exception("Já existe um usuuário cadastrado com este email!");

            return _novoUsuario;
        }

    }
}
