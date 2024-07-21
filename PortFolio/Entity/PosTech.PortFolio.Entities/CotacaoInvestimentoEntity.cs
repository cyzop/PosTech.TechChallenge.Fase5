namespace PosTech.PortFolio.Entities
{
    public class CotacaoAtivoEntity : AtivoEntity
    {
        public double Cotacao {  get; private set; }    
        public DateTime DataCotacao { get; private set; }

        public CotacaoAtivoEntity(TipoAtivo tipo, string codigo, string nome, double cotacao, DateTime dataCotacao, string id, DateTime data):base(tipo, nome, codigo, id, data)
        {
            Cotacao = cotacao;
            DataCotacao = dataCotacao;
        }
    }
}
