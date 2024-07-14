using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Repository.Sql
{
    public class AtivoRepository : EFRepository<AtivoEntity>, IAtivoRepository
    {
        public AtivoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public AtivoEntity ConsultaPorCodigo(string codigo)
        {
            var ativo = _context.Ativo
                .FirstOrDefault(c => c.Codigo == codigo) ?? throw new Exception($"Ativo {codigo} não existe!");
            return ativo;
        }
    }
}
