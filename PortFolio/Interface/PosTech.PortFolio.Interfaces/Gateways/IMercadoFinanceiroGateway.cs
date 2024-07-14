using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Interfaces.Gateways
{
    public interface  IMercadoFinanceiroGateway
    {
        List<CotacaoAtivoEntity> GetCotacoes(List<AtivoEntity> ativos);
    }
}
