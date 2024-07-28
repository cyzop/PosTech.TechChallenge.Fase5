namespace PosTech.PortFolio.Api.Model
{
    public class PortFolioModel
    {
        public string? Id { get; set; }
        public string ClienteId { get; set; }
        public required string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
