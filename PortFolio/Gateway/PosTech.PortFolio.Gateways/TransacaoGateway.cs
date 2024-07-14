using PosTech.PortFolio.Repository.Sql.Interface;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Gateways;

namespace PosTech.PortFolio.Gateways
{
    public class TransacaoGateway : ITransacaoGateway
    {
        private readonly ITransacaoRepository _database;

        public TransacaoGateway(ITransacaoRepository database)
        {
            _database = database;
        }

        public List<TransacaoEntity> ObterPorAtivoePortFolio(string ativoId, string portFolioId)
        {
            return _database.ConsultarPorAtivoEPortFolio(ativoId, portFolioId)?.ToList();
        }

        public TransacaoEntity ObterPorId(string id) => _database.ConsultarPorId(id);

        public List<TransacaoEntity> ObterPorPeriodo(DateTime datainicio, DateTime datafim)
        {
            return _database.ConsultarPorPeriodo(datainicio, datafim)?.ToList();
        }

        public List<TransacaoEntity> ObterPorPortFolio(string portFolioId)
        {
            return _database.ConsultarPorPortFolio(portFolioId)?.ToList();    
        }

        public List<TransacaoEntity> ObterTodos()
        {
            return _database.ConsultarTodos().ToList();
        }

        public void RegistrarTransacao(TransacaoEntity transacao)=> _database.Incluir(transacao);
       
    }
}
