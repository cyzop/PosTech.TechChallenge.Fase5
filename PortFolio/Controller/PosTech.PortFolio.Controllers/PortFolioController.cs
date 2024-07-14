using PosTech.PortFolio.Adapter;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases.PortFolio;

namespace PosTech.PortFolio.Controllers
{
    public class PortFolioController : IPortFolioController
    {
        readonly IPortFolioGateway _gateway;
        readonly IUsuarioGateway _usuarioGateway;

        public PortFolioController(IPortFolioGateway gateway, IUsuarioGateway usuarioGateway)
        {
            _gateway = gateway;
            _usuarioGateway = usuarioGateway;
        }

        public IEnumerable<PortFolioDao> ListarPorUsuario(string usuarioId)
        {
            return _gateway.ObterPorUsuario(usuarioId)?.Select(e => PortFolioDaoAdapter.GetDaoFromEntity(e));
        }

        public IEnumerable<PortFolioDao> ListarTodos()
        {
            return _gateway.ObterTodos()?.Select(e => PortFolioDaoAdapter.GetDaoFromEntity(e));
        }

        public PortFolioDao ObterPorId(string id)
        {
            return PortFolioDaoAdapter.GetDaoFromEntity(_gateway.ObterPorId(id));
        }

        public PortFolioDao RegistrarPortFolio(PortFolioDao portFolioDao)
        {
            var cliente = _usuarioGateway.ObterPorId(portFolioDao.UsuarioDao.Id);
            var portFoliosUsuario = _gateway.ObterPorUsuario(portFolioDao.UsuarioDao.Id);

            var novoPortFolio = new PortFolioEntity()
            {
                Nome = portFolioDao.Nome,
                Cliente = cliente,
                ClienteId = portFolioDao.UsuarioDao.Id,
                Descricao = portFolioDao.Descricao,
                DataCriacao = DateTime.Now,
            };

            //PortFolio use case
            RegistrarPortFolioUseCase registroPortFolio = new RegistrarPortFolioUseCase(novoPortFolio, portFoliosUsuario);
            var portFolio = registroPortFolio.VerificarPortFolio();

            //transacao gateway (registrar a transacao)
            _gateway.RegistrarPortFolio(portFolio);

            return PortFolioDaoAdapter.GetDaoFromEntity(portFolio);
        }
    }
}