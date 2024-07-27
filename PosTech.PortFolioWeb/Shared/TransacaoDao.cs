using System.ComponentModel.DataAnnotations;

namespace PosTech.PortFolioWeb.Shared
{
    public class TransacaoDao
    {

        public string Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public string TipoTransacao { get; set; }
        public string PortFolioId { get; set; }
        public PortFolioDao PortFolio { get; set; }
        public string AtivoId { get; set; }
        public AtivoTransacaoDao AtivoTransacao { get; set; }
    }
}
