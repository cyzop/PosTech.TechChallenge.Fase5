using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Gateways
{
    public class AtivoGateway : IAtivoGateway
    {
        private readonly IAtivoRepository _database;

        public AtivoGateway(IAtivoRepository database)
        {
            _database = database;
        }

        public AtivoEntity ObterPorCodigo(string codigo)=> _database.ConsultaPorCodigo(codigo);
        

        public List<AtivoEntity> ObterTodos() => _database.ConsultarTodos().ToList();
        
    }

    
}
