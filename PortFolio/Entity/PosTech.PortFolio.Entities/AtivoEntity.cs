namespace PosTech.PortFolio.Entities
{
    public class AtivoEntity : EntityBase
    {
        public TipoAtivo Tipo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

    }
}
