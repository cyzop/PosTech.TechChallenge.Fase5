namespace PosTech.PortFolio.Entities
{
    public class PortFolioEntity
    {
        public int Id { get; }
        public ClienteEntity Cliente { get; }
        public string Nome { get; }
        public string Descricao { get; }

        public PortFolioEntity(int id, ClienteEntity cliente, string nome, string descricao)
        {
            Id = id;
            Cliente = cliente;
            Nome = nome;
            Descricao = descricao;
        }
    }
}