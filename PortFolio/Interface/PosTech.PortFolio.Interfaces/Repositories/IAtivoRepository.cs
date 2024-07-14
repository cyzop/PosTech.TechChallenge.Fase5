using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Repositories
{
    public interface IAtivoRepository : IRepository<AtivoEntity>
    {
        public AtivoEntity ConsultaPorCodigo(string codigo);
    }
}
