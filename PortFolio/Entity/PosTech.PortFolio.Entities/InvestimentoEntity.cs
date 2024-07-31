namespace PosTech.PortFolio.Entities
{
    public class InvestimentoEntity
    {
        public AtivoEntity Ativo { get; private set; }
        public int Quantidade { get; private set; }
        public double Valor { get; private set; }

        public InvestimentoEntity() { }
        public InvestimentoEntity(AtivoEntity ativo, int quantidade, double valor)
        {
            Ativo = ativo;
            Quantidade = quantidade;
            Valor = valor;
        }

        public void SetQuantidade(int quantidade) => this.Quantidade = quantidade;
    }
}
