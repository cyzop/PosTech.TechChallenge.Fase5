namespace PosTech.PortFolio.Api.Model
{
    public class TransacaoModel
    {
        public required string PortFolioId {  get; set; }
        public required string AtivoId { get; set; }
        public required int Quantidade { get;set; }
        public required double Preco { get; set; }
    }
}
