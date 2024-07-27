using PosTech.PortFolioWeb.Shared;
using System.Net;

namespace PosTech.PortFolioWeb.Server.Services
{
    public class PortfoliosApi
    {
        private readonly HttpClient _httpCliente;

        public PortfoliosApi(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("PortFolioAPI");
        }

        public async Task<ICollection<PortFolioDao>> GetPortFoliosAsync(string userKey)
        {
            try
            {
                string url = $"PortFolio/PortFoliosUsuario/{WebUtility.UrlEncode(userKey)}";
                return await _httpCliente.GetFromJsonAsync<ICollection<PortFolioDao>>(url); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
