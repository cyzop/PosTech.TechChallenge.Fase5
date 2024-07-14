namespace PosTech.PortFolio.DAO
{
    public class TransacaoDao
    {
        public string Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public string TipoTransacao { get; set; }
        public PortFolioDao PortFolio { get; set; }
        public AtivoTransacaoDao AtivoTransacao { get; set; }
    }
}
