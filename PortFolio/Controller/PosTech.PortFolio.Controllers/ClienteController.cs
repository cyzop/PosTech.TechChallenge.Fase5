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

        public UsuarioDao AtualizarUsuario(UsuarioDao usuario)
        {
            var usuarioBase = _usuarioGateway.ObterPorId(usuario.Id);

            var usuarioEntity = new ClienteEntity(usuario.Nome, usuarioBase.Email, usuario.Id, usuarioBase.DataCriacao);

            var registroPaciente = new AtualizarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarExistente();

            //Atualização das informações
            usuarioBase.Nome = usuario.Nome;

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioBase);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            _usuarioGateway.AtualizarUsuario(usuarioNomeFormatado);

            return usuario;
        }

        public UsuarioDao AtualizarUsuario(NovoUsuarioDao usuario)
        {
            var usuarioBase = _usuarioGateway.ObterPorEmail(usuario.Email);

            var usuarioEntity = new ClienteEntity(usuario.Nome, usuario.Email, usuario.Id, usuarioBase.DataCriacao)
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };

            var registroPaciente = new RegistrarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioEntity);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            _usuarioGateway.RegistrarUsuario(usuarioNomeFormatado);

            return usuario;
        }

        public UsuarioDao IncluirUsuario(NovoUsuarioDao usuario)
        {
            var usuarioEntity = new ClienteEntity(usuario.Nome, usuario.Email, usuario.Id, DateTime.Now);

            var usuarioBase = _usuarioGateway.ObterPorEmail(usuario.Email);

            var registroPaciente = new RegistrarUsuarioUseCase(usuarioEntity, usuarioBase);
            //RN verifica se ainda não existe email cadastrado
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var usuarioNomeFormatter = new FormatarNomeUseCase(usuarioEntity);
            var usuarioNomeFormatado = usuarioNomeFormatter.Formatar();

            _usuarioGateway.RegistrarUsuario(usuarioNomeFormatado);
            usuario.SetId(usuarioNomeFormatado.Id);
            usuario.SetDataCriacao(usuarioNomeFormatado.DataCriacao);

            return usuario;
        }

        public UsuarioDao ObterUsuarioPorEmail(string email)
        {
            var usuarioBase = _usuarioGateway.ObterPorEmail(email);
            if (usuarioBase != null)
                return new UsuarioDao(usuarioBase.Id, usuarioBase.Nome, usuarioBase.Email, usuarioBase.DataCriacao);
            else
                return null;
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