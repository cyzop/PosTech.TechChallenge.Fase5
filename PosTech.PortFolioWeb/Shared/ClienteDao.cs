namespace PosTech.PortFolioWeb.Shared
{
    public class ClienteDao
    {
        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.MinValue;
    }
}
