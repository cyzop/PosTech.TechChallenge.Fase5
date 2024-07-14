using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<ClienteEntity>
    {
        ClienteEntity ConsultarPorEmail(string email);
    }
}
