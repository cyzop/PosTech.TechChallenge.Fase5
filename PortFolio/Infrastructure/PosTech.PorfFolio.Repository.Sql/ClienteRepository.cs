using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Repository.Sql
{
    public class ClienteRepository : EFRepository<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ClienteEntity ConsultarPorEmail(string email)
        {
            return _context.Cliente.FirstOrDefault(c=>c.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
