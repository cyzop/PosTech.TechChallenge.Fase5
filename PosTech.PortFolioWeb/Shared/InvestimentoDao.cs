namespace PosTech.PortFolioWeb.Shared
{
    public class InvestimentoDao 
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Quantidade { get; set; }
        public string ClienteId { get; set; }

        public double ValorTotal { get; set; }
    }
}
