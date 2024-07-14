namespace PosTech.PortFolio.Entities
{
    public class PortFolioEntity : EntityBase
    {
        public string ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}