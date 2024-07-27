using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Services
{
    public class InvestimentoAPI
    {
        private readonly HttpClient _httpCliente;

        public InvestimentoAPI(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("InvestimentoAPI");
        }

        public async Task<ICollection<InvestimentoDao>> GetAtivosAsync(string portFolioId)
        {
            return await _httpCliente.GetFromJsonAsync<ICollection<InvestimentoDao>>($"Investimento/ListarAtivosPortfolio/{portFolioId}");
        }
    }
}
