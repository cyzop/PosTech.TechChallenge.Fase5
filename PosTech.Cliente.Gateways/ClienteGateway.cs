using PosTech.Cliente.Interfaces.Gateways;
using PosTech.Cliente.Interfaces.Repositories;
using PostTech.Cliente.Entities;

namespace PosTech.Cliente.Gateways
{
    public class ClienteGateway : IClienteGateway
    {
        readonly IClienteRepository _database;

        public ClienteGateway(IClienteRepository database)
        {
            _database = database;
        }

        public UsuarioEntity ObterPorEmail(string email)=>
            (_database.ObterPorEmail(email));
        

        public UsuarioEntity ObterPorId(string id)=>
            (_database.ObterPorId(id));
        

        public UsuarioEntity RegistrarUsuario(UsuarioEntity novoUsuario)
        => _database.IncluirUsuario(novoUsuario);

        public IEnumerable<UsuarioEntity> ObterUsuarios()
            => _database.ObterUsuarios();
        
    }
}