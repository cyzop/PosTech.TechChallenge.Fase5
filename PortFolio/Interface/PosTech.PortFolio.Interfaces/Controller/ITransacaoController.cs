using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Controller
{
    public interface ITransacaoController
    {
        IEnumerable<TransacaoDao> ListarTodos();
        IEnumerable<TransacaoDao> ListarPorPortFolio(string portfolioId);

        TransacaoDao ObterPorId(string id);

        TransacaoDao RegistrarCompra(PortFolioDao portFolioDao, AtivoTransacaoDao ativoDao);
        TransacaoDao RegistrarVenda(PortFolioDao portFolioDao, AtivoTransacaoDao ativoDao);
    }
}
