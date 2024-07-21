using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Gateways;

namespace PosTech.PortFolio.Gateways
{
    public class MercadoFinanceiroGateway : IMercadoFinanceiroGateway
    {
        private readonly Random random = null;
        const double minRandomPrice = 10.0; // preço mínimo
        const double maxRandomPrice = 100.0; // preço máximo

        public MercadoFinanceiroGateway()
        {
            random = new Random();
        }

        public List<CotacaoAtivoEntity> GetCotacoes(List<AtivoEntity> ativos)
            => ativos.Select(a => new CotacaoAtivoEntity(a.Tipo, a.Codigo, a.Nome, GenerateRandomPrice(), DateTime.Now, a.Id, a.DataCriacao)).ToList();

        private double GenerateRandomPrice()
        {
            return Math.Round(minRandomPrice + (random.NextDouble() * (maxRandomPrice - minRandomPrice)), 2);
        }
    }
}

