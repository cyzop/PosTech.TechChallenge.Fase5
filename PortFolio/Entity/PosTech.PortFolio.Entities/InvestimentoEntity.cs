namespace PosTech.PortFolio.Entities
{
    public class InvestimentoEntity
    {
        public AtivoEntity Ativo { get; private set; }
        public int Quantidade { get; private set; }

        public InvestimentoEntity(AtivoEntity ativo, int quantidade)
        {
            Ativo = ativo;
            Quantidade = quantidade;
        }

        public void SetQuantidade(int quantidade) => this.Quantidade = quantidade;
    }
}
