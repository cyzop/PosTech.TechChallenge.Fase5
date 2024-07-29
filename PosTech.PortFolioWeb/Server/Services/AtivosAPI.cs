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
            try
            {
                var ret = await _httpCliente.GetFromJsonAsync<ICollection<AtivoDao>>("Ativo/Listar");
                return await Task<ICollection<AtivoDao>>.Factory.StartNew(() => ret);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
