using PosTech.PortFolio.DAO;

namespace PosTech.PortFolio.Interfaces.Controller
{
    public interface IMercadoFinanceiroController
    {
        IEnumerable<CotacaoAtivoDao> ListarAtivos();
    }
}
