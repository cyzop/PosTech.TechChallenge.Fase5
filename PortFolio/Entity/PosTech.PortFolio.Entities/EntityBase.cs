namespace PosTech.PortFolio.Entities
{
    public abstract class EntityBase
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }

        protected EntityBase() { }

        protected EntityBase(string id, DateTime dataCriacao)
        {
            Id = id;
            DataCriacao = dataCriacao;
        }
    }
}