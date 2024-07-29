using Newtonsoft.Json;
using PosTech.PortFolioWeb.Shared;
using System.Text;

namespace PosTech.PortFolioWeb.Server.Services
{
    public class ClienteAPI
    {
        private readonly HttpClient _httpCliente;

        public ClienteAPI(IHttpClientFactory factory)
        {
            _httpCliente = factory.CreateClient("ClienteAPI");
        }

        public async Task<ClienteDao> GetClienteAsync(string email)
        {
            var ret = await _httpCliente.GetFromJsonAsync<ClienteDao>($"Cliente/Email/{email}");
            if (ret != null)
                return Task<ClienteDao>.Factory.StartNew(() => ret).Result;
            else
                throw new Exception("Cliente não localizado!");
        }

        public async Task<ClienteDao> PostClienteAsync(ClienteDao cliente)
        {
            string url = $"Cliente/Atualizar/";
            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var ret = await _httpCliente.PostAsync(url, content);

            if (ret.IsSuccessStatusCode)
            {
                var x = await ret.Content.ReadFromJsonAsync<ClienteDao>();
                return Task<ClienteDao>.Factory.StartNew(() => x).Result;
            }
            else
                throw new Exception(ret.StatusCode.ToString());
        }
    }
}
