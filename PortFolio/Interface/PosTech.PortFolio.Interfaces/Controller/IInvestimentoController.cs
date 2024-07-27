using PosTech.PortFolio.DAO;

namespace PosTech.PortFolio.Interfaces.Controller
{
    public interface IInvestimentoController
    {
        List<InvestimentoDao> ListarAtivosInvestidos(PortFolioDao portFolio);
    }
}