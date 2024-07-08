using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface ITransacaoGateway
    {
        void RegistrarTransacao(TransacaoEntity transacao);
    }
}
