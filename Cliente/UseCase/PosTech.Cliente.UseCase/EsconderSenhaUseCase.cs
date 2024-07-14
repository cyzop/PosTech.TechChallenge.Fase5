using PosTech.Cliente.Entities;

namespace PosTech.Cliente.UseCases
{
    public class EsconderSenhaUseCase
    {
        private readonly UsuarioEntity _usuario;

        public EsconderSenhaUseCase(UsuarioEntity usuario)
        {
            _usuario = usuario;
        }

        public UsuarioEntity EsconderSenha()
        {
            _usuario.SetSenha("*********");
            return _usuario;
        }
        
    }
}
