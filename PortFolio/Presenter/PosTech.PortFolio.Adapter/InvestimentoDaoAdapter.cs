using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Adapter
{
    public class InvestimentoDaoAdapter
    {
        public static InvestimentoDao GetDaoFromEntity(InvestimentoEntity entity)
        {
            return new InvestimentoDao()
            {
               Id = entity.Ativo.Id,
               Codigo = entity.Ativo.Codigo,
               Nome = entity.Ativo.Nome,
               Tipo = entity.Ativo.Tipo.ToString(),
               Quantidade = entity.Quantidade,
               ValorTotal = entity.Valor
            };
        }
    }

    
}
