namespace PosTech.PortFolio.Entities
{
    public class AtivoEntity
    {
        public int Id { get; }
        public TipoAtivo Tipo { get; }
        public string Nome { get; }
        public string Codigo { get; }

        public AtivoEntity(int id, TipoAtivo tipo, string nome, string codigo)
        {
            Id = id;
            Tipo = tipo;
            Nome = nome;
            Codigo = codigo;
        }
    }
}
