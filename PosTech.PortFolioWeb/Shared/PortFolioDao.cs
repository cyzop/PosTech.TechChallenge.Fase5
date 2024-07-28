using System.ComponentModel.DataAnnotations;

namespace PosTech.PortFolioWeb.Shared
{
    public class PortFolioDao
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "PortFolio não identificado, informe um nome para o PortFolio antes de continuar")]
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? ClienteId { get; set; }

    }
}
