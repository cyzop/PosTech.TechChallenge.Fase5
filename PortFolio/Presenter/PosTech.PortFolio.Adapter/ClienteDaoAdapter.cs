using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Adapter
{
    public static class ClienteDaoAdapter
    {
        public static UsuarioDao GetDaoFromEntity(ClienteEntity entity)
        {
            if (entity == null)
                return null;

            return new UsuarioDao(entity.Id, entity.Nome, entity.Email);
        }
    }
}
