namespace PosTech.PortFolioWeb.Shared
{
    public class AtivoTransacaoDao : AtivoDao
    {
        public required double Preco { get; set; }
        public required int Quantidade { get; set; }
    }
}
