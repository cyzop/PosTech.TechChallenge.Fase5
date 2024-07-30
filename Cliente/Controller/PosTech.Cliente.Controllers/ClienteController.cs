using PosTech.Cliente.Interfaces.Controller;
using PosTech.Cliente.Interfaces.Gateways;
using PosTech.Cliente.UseCases;
using PosTech.Cliente.Entities;

namespace PosTech.Cliente.DAO
{
    public class ClienteController : IClienteController
    {
        readonly IClienteGateway _usuarioGateway;

        public ClienteController(IClienteGateway usuarioGateway)
        {
            _usuarioGateway = usuarioGateway;
        }

        public UsuarioDao AtualizarUsuario(NovoUsuarioDao usuario)
        {
            var usuarioEntity = new UsuarioEntity(usuario.Id, usuario.Nome, usuario.Email);

            var usuarioBase = _usuarioGateway.ObterPorEmail(usuario.Email);

            var registroPaciente = new RegistrarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioEntity);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            var novoUsuario = _usuarioGateway.RegistrarUsuario(usuarioNomeFormatado);

            return usuario;
        }

        public UsuarioDao IncluirUsuario(NovoUsuarioDao usuario)
        {
            var usuarioEntity = new UsuarioEntity(usuario.Id, usuario.Nome, usuario.Email);

            var usuarioBase = _usuarioGateway.ObterPorEmail(usuario.Email);
            
            var registroPaciente = new RegistrarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioEntity);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            var novoUsuario = _usuarioGateway.RegistrarUsuario(usuarioNomeFormatado);
            usuario.SetId(novoUsuario.Id);
            return usuario;
        }

        public UsuarioDao ObterUsuarioPorEmail(string email)
        {
            var usuarioBase = _usuarioGateway.ObterPorEmail(email);
            return new UsuarioDao(usuarioBase.Id, usuarioBase.Nome, usuarioBase.Email);
        }

        public UsuarioDao ObterUsuarioPorId(string id)
        {
            var usuarioBase = _usuarioGateway.ObterPorEmail(id);
            return new UsuarioDao(usuarioBase.Id, usuarioBase.Nome, usuarioBase.Email);
        }

        public IEnumerable<UsuarioDao> ListarUsuarios()
        {
            var usuarios = _usuarioGateway.ObterUsuarios();
            var usuariosDao = usuarios?.Select(e => 
                                new UsuarioDao(e.Id, e.Nome, e.Email));
            return usuariosDao?.ToList();
        }
    }
}