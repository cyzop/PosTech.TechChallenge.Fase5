using Newtonsoft.Json;
using PosTech.PortFolioWeb.Shared;
using System.Text;

namespace PosTech.PortFolioWeb.Server.Services
{
    public class TransacaoAPI
    {
        private readonly HttpClient _httpCliente;

        public TransacaoAPI(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("TransacaoAPI");
        }

        public async Task<ICollection<TransacaoDao>> GetTransacoesAsync(string id)
        {
            try
            {
                string url = $"Transacao/Listar/{id}";
                var ret = await _httpCliente.GetFromJsonAsync<ICollection<TransacaoDao>>(url);
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NegociacaoAtivoDao> PostCompraAsync(NegociacaoAtivoDao transacao)
        {
            try
            {
                string url = $"Transacao/Comprar/";
                var json = JsonConvert.SerializeObject(transacao);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var ret = await _httpCliente.PostAsync(url, content);

                if (ret.IsSuccessStatusCode)
                {
                    
                    var x = await ret.Content.ReadFromJsonAsync<NegociacaoAtivoDao>();
                    return Task<NegociacaoAtivoDao>.Factory.StartNew(() => x).Result;
                }
                else
                    throw new Exception(ret.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NegociacaoAtivoDao> PostVendaAsync(NegociacaoAtivoDao transacao)
        {
            try
            {
                string url = $"Transacao/Vender/";
                var json = JsonConvert.SerializeObject(transacao);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var ret = await _httpCliente.PostAsync(url, content);

                if (ret.IsSuccessStatusCode)
                {
                    var x = await ret.Content.ReadFromJsonAsync<NegociacaoAtivoDao>();
                    return Task<NegociacaoAtivoDao>.Factory.StartNew(() => x).Result;
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
