using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Adapter
{
    public static class AtivoDaoAdapter
    {
        public static AtivoDao GetDaoFromEntity(AtivoEntity entity)
        {
            return new AtivoDao()
            {
                Codigo = entity.Codigo,
                Nome = entity.Nome, 
                Tipo = entity.Tipo.ToString()
            };
        }
    }
}
