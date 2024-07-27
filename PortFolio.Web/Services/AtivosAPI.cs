using PortFolio.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;

namespace PortFolio.Web.Services
{
    public class AtivosAPI
    {
        private readonly HttpClient _httpCliente;

        public AtivosAPI(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("API");
        }

        public async Task<ICollection<AtivoDao>> GetAtivosAsync()
        {
            return await _httpCliente.GetFromJsonAsync<ICollection<AtivoDao>>("Ativo/Listar");
        }
    }
}
