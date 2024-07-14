using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.Cliente;
using PosTech.TechChallenge.Shared;

namespace PosTech.PortFolio.UseCases
{
    public class RegistrarUsuarioUseCase
    {
        private readonly ClienteEntity _novoUsuario;
        private readonly ClienteEntity _usuario;

        public RegistrarUsuarioUseCase(ClienteEntity novoUsuario, ClienteEntity usuarioBase) 
        {
            _novoUsuario = novoUsuario;
            _usuario = usuarioBase;
        }

        public ClienteEntity VerificarNovo()
        {
            AssertionConcern.AssertArgumentNotEmpty(_novoUsuario.Nome, ValidationMessages.MensagemNomeVazio);
            AssertionConcern.AssertArgumentNotEmpty(_novoUsuario.Senha, ValidationMessages.MensagemSenhaVazia);
            AssertionConcern.AssertArgumentNotEmpty(_novoUsuario.Email, ValidationMessages.MensagemEmailVazio);

            _novoUsuario.DataCriacao = DateTime.Now;
            _novoUsuario.Id = Guid.NewGuid().ToString();

            AssertionConcern.AssetArgumentNotEquals(_novoUsuario?.Email, _usuario?.Email, ValidationMessages.MensagemEmailDuplicado);

            return _novoUsuario;
        }
    }
}
