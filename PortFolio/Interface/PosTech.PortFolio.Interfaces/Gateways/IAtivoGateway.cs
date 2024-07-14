

using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface IAtivoGateway
    {
        AtivoEntity ObterPorCodigo(string codigo);
        List<AtivoEntity> ObterTodos();
    }
}
