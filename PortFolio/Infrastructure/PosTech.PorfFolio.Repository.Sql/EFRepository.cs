using Microsoft.EntityFrameworkCore;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Repositories;

namespace PosTech.PortFolio.Repository.Sql
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Alterar(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public T ConsultarPorId(string id)
            => _dbSet.FirstOrDefault(e => e.Id == id);

        public ICollection<T> ConsultarTodos()
            => _dbSet.ToList();

        public ICollection<T> ConsultarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _dbSet.Where(e => e.DataCriacao >= inicio && e.DataCriacao <= fim)
                .ToList();
        }

        public void Incluir(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Remover(string id)
        {
           _dbSet.Remove(ConsultarPorId(id));
            _context.SaveChanges();
        }
    }
}
