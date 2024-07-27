using PosTech.PortFolioWeb.Shared;

namespace PosTech.PortFolioWeb.Server.Services
{
    public class CotacaoAtivosAPI
    {
        private readonly HttpClient _httpCliente;

        public CotacaoAtivosAPI(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("CotacaoAPI");
        }

        public async Task<ICollection<CotacaoAtivoDao>> GetAtivosAsync()
        {
            return await _httpCliente.GetFromJsonAsync<ICollection<CotacaoAtivoDao>>("Investimento/ListarAtivos");
        }
    }
}
