using PosTech.PortFolio.DAO;

namespace PosTech.PortFolio.Interfaces.Controller
{
    public interface IAtivoController
    {
       IEnumerable<AtivoDao> ListarDisponiveis();
    }
}
