using PosTech.PortFolioWeb.Client.Pages.Example.Model;

namespace PosTech.PortFolioWeb.Client.Pages.Example.Services
{
    public class EntidadeService
    {
        private List<Entidade> lista;

        public EntidadeService()
        {
            lista = new List<Entidade>();
        }

        public async Task Update(Entidade entidade)
        {
            var item = lista.First(x=>x.Id == entidade.Id);
            var index = lista.IndexOf(item);
            lista[index] = entidade;
        }
        public async Task Add(Entidade entidade)
        {
            lista.Add(entidade);
        }

        public async Task<Entidade> GetById(string entidadeId)
        {
            return lista.FirstOrDefault(i => i.Equals(entidadeId));
        }

        public async Task Remove(Entidade item)
        {
            lista.Remove(item);
        }

        public async Task<List<Entidade>> GetAll()
        {
            return lista;
        }
    }
}
