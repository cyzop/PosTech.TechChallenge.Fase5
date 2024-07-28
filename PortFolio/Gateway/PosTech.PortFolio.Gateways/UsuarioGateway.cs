using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Gateways
{
    public class UsuarioGateway : IUsuarioGateway
    {
        readonly IClienteRepository _database;

        public UsuarioGateway(IClienteRepository database)
        {
            _database = database;
        }

        public ClienteEntity ObterPorEmail(string email) =>
            (_database.ConsultarPorEmail(email));


        public ClienteEntity ObterPorId(string id) =>
            (_database.ConsultarPorId(id));


        public void RegistrarUsuario(ClienteEntity novoUsuario)
        => _database.Incluir(novoUsuario);

        public IEnumerable<ClienteEntity> ObterUsuarios()
            => _database.ConsultarTodos();

        public ClienteEntity AtualizarUsuario(ClienteEntity usuario)
            => _database.Atualizar(usuario);
    }
}