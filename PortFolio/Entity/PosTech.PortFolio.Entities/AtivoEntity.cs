using PosTech.PortFolio.Assertion;

namespace PosTech.PortFolio.Entities
{
    public class AtivoEntity : EntityBase
    {
        public TipoAtivo Tipo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public AtivoEntity(TipoAtivo tipo, string nome, string codigo, string id, DateTime data) : base(id, data)
        {
            Tipo = tipo;
            Nome = nome;
            Codigo = codigo;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentDate(base.DataCriacao, DateTime.MinValue, DateTime.Now, Messages.Ativo.ValidationMessages.MensagemDataCriacaoInvalida);
            AssertionConcern.AssertArgumentNotEmpty(Nome, Messages.Ativo.ValidationMessages.MensagemNomeVazio);
            AssertionConcern.AssertArgumentNotEmpty(Codigo, Messages.Ativo.ValidationMessages.MensagemCodigoVazio);
        }
    }
}
