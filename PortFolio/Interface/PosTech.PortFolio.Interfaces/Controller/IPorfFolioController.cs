using PosTech.PortFolio.DAO;

namespace PosTech.PortFolio.Interfaces.Controller
{
    public interface IPortFolioController
    {
        IEnumerable<PortFolioDao> ListarTodos();
        PortFolioDao ObterPorId(string id);
        IEnumerable<PortFolioDao> ListarPorUsuario(string userMail);

        PortFolioDao RegistrarPortFolio(PortFolioDao portFolioDao);
        PortFolioDao AtualizarPortFolio(PortFolioDao portFolioDao);
    }
}
