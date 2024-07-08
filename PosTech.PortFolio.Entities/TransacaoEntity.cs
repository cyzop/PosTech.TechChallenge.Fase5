namespace PosTech.PortFolio.Entities
{
    public class TransacaoEntity
    {
        public int Id { get; }
        public PortFolioEntity PorfFolio { get; }
        public AtivoEntity Ativo { get; }
        public TipoTransacao TipoTransacao { get; }
        public int Quantidade { get; private set; }
        public double Preco { get; private set; }
        public DateTime DataTransacao { get; private set; }

        public TransacaoEntity(int id, TipoTransacao tipoTransacao, PortFolioEntity porfFolio, AtivoEntity ativo, int quantidade, double preco, DateTime dataTransacao)
        {
            Id = id;
            PorfFolio = porfFolio;
            Ativo = ativo;
            TipoTransacao = tipoTransacao;
            Quantidade = quantidade;
            Preco = preco;
            DataTransacao = dataTransacao;
        }
        public TransacaoEntity(TipoTransacao tipoTransacao, PortFolioEntity porfFolio, AtivoEntity ativo)
        {
            PorfFolio = porfFolio;
            Ativo = ativo;
            TipoTransacao = tipoTransacao;
        }

        public void SetQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }

        public void SetPreco(double preco)
        {
            Preco = preco;
        }

        public void SetDataTransacao(DateTime dataTransacao)
        {
            DataTransacao = dataTransacao;
        }
    }
}
