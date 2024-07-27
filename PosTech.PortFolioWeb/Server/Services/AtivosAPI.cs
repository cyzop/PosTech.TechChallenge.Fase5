using PosTech.PortFolioWeb.Shared;

namespace PortFolio.PortFolioWeb.Server.Services
{
    public class AtivosAPI
    {
        private readonly HttpClient _httpCliente;

        public AtivosAPI(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("AtivoAPI");
        }

        public async Task<ICollection<AtivoDao>> GetAtivosAsync()
        {
            return await _httpCliente.GetFromJsonAsync<ICollection<AtivoDao>>("Ativo/Listar");
        }
    }
}
