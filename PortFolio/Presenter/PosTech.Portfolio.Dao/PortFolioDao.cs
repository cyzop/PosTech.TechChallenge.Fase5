namespace PosTech.PortFolio.DAO
{
    public class PortFolioDao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }

        public UsuarioDao UsuarioDao { get; set; }
    }
}
