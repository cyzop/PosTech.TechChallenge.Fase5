using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Gateways
{
    public class PortFolioGateway : IPortFolioGateway
    {
        private readonly IPortFolioRepository _database;

        public PortFolioGateway(IPortFolioRepository database)
        {
            _database = database;
        }

        public PortFolioEntity ObterPorId(string id)=>_database.ConsultarPorId(id);

        public IEnumerable<PortFolioEntity> ObterPorUsuario(string usuarioId)
        {
            return _database.ConsultarPorUsuario(usuarioId);
        }

        public IEnumerable<PortFolioEntity> ObterTodos()
        {
            return _database.ConsultarTodos();
        }

        public void RegistrarPortFolio(PortFolioEntity portFolio)
        {
            _database.Incluir(portFolio);
        }

        public PortFolioEntity AtualizarPortFolio(PortFolioEntity portFolio)
        {
            _database.Atualizar(portFolio);
            return portFolio;
        }
    }
}
