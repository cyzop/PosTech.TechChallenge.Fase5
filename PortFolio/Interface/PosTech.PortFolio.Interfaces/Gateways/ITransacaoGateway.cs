using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface ITransacaoGateway
    {
        TransacaoEntity ObterPorId(string id);
        void RegistrarTransacao(TransacaoEntity transacao);

        List<TransacaoEntity> ObterPorPortFolio(string portFolioId);

        List<TransacaoEntity> ObterPorPeriodo(DateTime datainicio, DateTime datafim);

        List<TransacaoEntity> ObterTodos();
    }

}
