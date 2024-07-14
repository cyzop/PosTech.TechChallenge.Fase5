using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases;

namespace PosTech.PortFolio.Controllers
{
    public class ClienteController : IClienteController
    {
        readonly IUsuarioGateway _usuarioGateway;

        public ClienteController(IUsuarioGateway usuarioGateway)
        {
            _usuarioGateway = usuarioGateway;
        }

        public UsuarioDao AtualizarUsuario(NovoUsuarioDao usuario)
        {
            var usuarioEntity = new ClienteEntity()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            var usuarioBase = _usuarioGateway.ObterPorEmail(usuario.Email);

            var registroPaciente = new RegistrarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioEntity);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            //RN formatar senha (hash)
            var usuarioHashFormatter = new GerarHashSenhaUseCase(usuarioNomeFormatado);
            var usuarioSenhaFormatado = usuarioHashFormatter.Formatar();

            _usuarioGateway.RegistrarUsuario(usuarioSenhaFormatado);

            //Hide password
            var passwordCleanner = new EsconderSenhaUseCase(usuarioSenhaFormatado);
            var usuarioSenhaOculta = passwordCleanner.EsconderSenha();
            usuario.SetSenha(usuarioSenhaOculta.Senha);
           
            return usuario;
        }

        public UsuarioDao IncluirUsuario(NovoUsuarioDao usuario)
        {
            var usuarioEntity = new ClienteEntity()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            var usuarioBase = _usuarioGateway.ObterPorEmail(usuario.Email);
            
            var registroPaciente = new RegistrarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioEntity);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            //RN formatar senha (hash)
            var usuarioHashFormatter = new GerarHashSenhaUseCase(usuarioNomeFormatado);
            var usuarioSenhaFormatado = usuarioHashFormatter.Formatar();

            _usuarioGateway.RegistrarUsuario(usuarioSenhaFormatado);
            usuario.SetId(usuarioSenhaFormatado.Id);

            //Hide password
            var passwordCleanner = new EsconderSenhaUseCase(usuarioSenhaFormatado);
            var usuarioSenhaOculta = passwordCleanner.EsconderSenha();

            usuario.SetSenha(usuarioSenhaOculta.Senha);
            
            

            return usuario;
        }

        public UsuarioDao ObterUsuarioPorEmail(string email)
        {
            var usuarioBase = _usuarioGateway.ObterPorEmail(email);
            return new UsuarioDao(usuarioBase.Id, usuarioBase.Nome, usuarioBase.Email);
        }

        public UsuarioDao ObterUsuarioPorId(string id)
        {
            var usuarioBase = _usuarioGateway.ObterPorId(id);
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