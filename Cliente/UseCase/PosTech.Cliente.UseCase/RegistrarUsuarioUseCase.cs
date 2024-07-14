using PosTech.Cliente.Entities;

namespace PosTech.Cliente.UseCases
{
    public class RegistrarUsuarioUseCase
    {
        private readonly UsuarioEntity _novoUsuario;
        private readonly UsuarioEntity _usuario;

        public RegistrarUsuarioUseCase(UsuarioEntity novoUsuario, UsuarioEntity usuarioBase) 
        {
            _novoUsuario = novoUsuario;
            _usuario = usuarioBase;
        }

        public UsuarioEntity VerificarNovo()
        {
            if (_novoUsuario?.Email == _usuario?.Email)
                throw new Exception("Já existe um usuuário cadastrado com este email!");

            return _novoUsuario;
        }


    }
}
