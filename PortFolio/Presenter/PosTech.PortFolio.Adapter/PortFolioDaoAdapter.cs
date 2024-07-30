using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Adapter
{
    public static class PortFolioDaoAdapter
    {
        public static PortFolioDao GetDaoFromEntity(PortFolioEntity entity)
        {
            if (entity == null)
                return null;

            return new PortFolioDao()
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Usuario = ClienteDaoAdapter.GetDaoFromEntity(entity.Cliente),
                Descricao = entity.Descricao,
                DataCriacao = entity.DataCriacao,
            };
        }
    }
}
