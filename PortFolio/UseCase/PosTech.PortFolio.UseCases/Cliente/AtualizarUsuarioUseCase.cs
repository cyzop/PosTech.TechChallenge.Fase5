
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.Cliente;

namespace PosTech.PortFolio.UseCases
{
    public class AtualizarUsuarioUseCase
    {
        private readonly ClienteEntity _novoUsuario;
        private readonly ClienteEntity _usuarioBase;

        public AtualizarUsuarioUseCase(ClienteEntity novoUsuario, ClienteEntity usuario)
        {
            _novoUsuario = novoUsuario;
            _usuarioBase = usuario;
        }
        public ClienteEntity VerificarExistente()
        {
            if (_usuarioBase == null)
                throw new Exception(ValidationMessages.MensagemUsuarioNaoEncontrado);

            if (_novoUsuario.Email == _usuarioBase.Email 
                && _novoUsuario.Id != _usuarioBase.Id)
                throw new Exception(ValidationMessages.MensagemEmailDuplicado);

            return _novoUsuario;
        }

    }
}
