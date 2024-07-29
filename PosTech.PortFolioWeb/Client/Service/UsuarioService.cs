namespace PosTech.PortFolioWeb.Client.Services
{
    public class UsuarioService
    {
        public string Id { get; private set; } = null;
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public void SetUsuario(string id, string name, DateTime data)
        {
            Id = id;
            Nome = name;
            DataCriacao = data;
        }

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }
    }
}
