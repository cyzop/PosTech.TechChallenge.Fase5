using Newtonsoft.Json;
using PosTech.PortFolioWeb.Shared;
using System.Net;
using System.Text;

namespace PosTech.PortFolioWeb.Server.Services
{
    public class PortfoliosApi
    {
        private readonly HttpClient _httpCliente;

        public PortfoliosApi(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("PortFolioAPI");
        }

        public async Task<PortFolioDao> GetPortFolioPorIdAsync(string id)
        {
            string url = $"PortFolio/{WebUtility.UrlEncode(id)}";
            return await _httpCliente.GetFromJsonAsync<PortFolioDao>(url);
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

        public async Task<PortFolioDao> PostAsync(PortFolioDao portfolio)
        {
            try
            {
                string url = $"PortFolio";
                var json = JsonConvert.SerializeObject(portfolio);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var ret = await _httpCliente.PostAsync(url, content);

                if (ret.IsSuccessStatusCode)
                {
                    var x = await ret.Content.ReadFromJsonAsync<PortFolioDao>();
                    return Task<PortFolioDao>.Factory.StartNew(() => x).Result;
                }
                else
                    throw new Exception(ret.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PortFolioDao> PutAsync(PortFolioDao portfolio)
        {
            try
            {
                string url = $"PortFolio";
                var json = JsonConvert.SerializeObject(portfolio);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var ret = await _httpCliente.PutAsync(url, content);

                if (ret.IsSuccessStatusCode)
                {
                    var x = await ret.Content.ReadFromJsonAsync<PortFolioDao>();
                    return Task<PortFolioDao>.Factory.StartNew(() => x).Result;
                }
                else
                    throw new Exception(ret.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
