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
    }
}
