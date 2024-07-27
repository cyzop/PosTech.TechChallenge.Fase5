using System.ComponentModel.DataAnnotations;

namespace PosTech.PortFolioWeb.Shared
{
    public class NegociacaoAtivoDao
    {
        [Required(ErrorMessage = "PortFolio não identificado, volte para a listagem de tente novamente")]
        public string PortFolioId { get; set; }
        [Required(ErrorMessage = "Ativo não informado, selecione um antes de continuar")]
        public string AtivoId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade de ativos não foi informada, informe um valor maior que zero")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Preço do Ativo não identificado")]
        public double Preco { get; set; }
    }
}
