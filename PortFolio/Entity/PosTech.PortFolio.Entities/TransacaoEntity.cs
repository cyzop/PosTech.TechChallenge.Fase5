using PosTech.PortFolio.Assertion;

namespace PosTech.PortFolio.Entities
{
    public class TransacaoEntity : EntityBase
    {
        public string PortFolioId { get; set; }
        public string AtivoId { get; set; }
        public virtual PortFolioEntity PortFolio { get; set; }
        public virtual AtivoEntity Ativo { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int Quantidade { get; private set; }
        public double Preco { get; private set; }

        public void SetQuantidade(int quantidade) => Quantidade = quantidade;
        public void SetPreco(double preco) => Preco = preco;

        public TransacaoEntity(PortFolioEntity portFolio, AtivoEntity ativo, TipoTransacao tipoTransacao, int quantidade, double preco, string id, DateTime data)
            : base(id, data)
        {
            PortFolioId = portFolio.Id;
            AtivoId = ativo.Id;
            PortFolio = portFolio;
            Ativo = ativo;
            TipoTransacao = tipoTransacao;
            Quantidade = quantidade;
            Preco = preco;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentMinValue(0, Quantidade, Messages.Ativo.ValidationMessages.MensagemQuantidadeAtivosInvalida);
            AssertionConcern.AssertDoublePositiveValue(Preco, Messages.Ativo.ValidationMessages.MensagemValorAtivoInvalido);
            AssertionConcern.AssertArgumentIsNull(Ativo, Messages.Transacao.ValidationMessages.MensagemAtivoVazio);
            AssertionConcern.AssertArgumentIsNull(PortFolio, Messages.Transacao.ValidationMessages.MensagemPortFolioVazio);
        }
    }
}
