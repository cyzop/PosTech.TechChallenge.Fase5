using System.ComponentModel.DataAnnotations;

namespace PosTech.PortFolio.Api.Model
{
    public class NovoClienteModel
    {
        public required string Nome { get; set; }
        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(8)]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }


    }
}
