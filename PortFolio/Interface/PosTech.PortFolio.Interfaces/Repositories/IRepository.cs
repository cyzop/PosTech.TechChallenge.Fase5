using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        abstract void Alterar(T entity);
        void Incluir(T entity);
        void Remover(string id);
        T ConsultarPorId(string id);
        ICollection<T> ConsultarTodos();

        ICollection<T> ConsultarPorPeriodo(DateTime inicio, DateTime fim);
    }
}
