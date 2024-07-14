using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.UseCases
{
    public class EsconderSenhaUseCase
    {
        private readonly ClienteEntity _usuario;

        public EsconderSenhaUseCase(ClienteEntity usuario)
        {
            _usuario = usuario;
        }

        public ClienteEntity EsconderSenha()
        {
            _usuario.Senha = "*********";
            return _usuario;
        }
        
    }
}
