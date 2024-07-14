namespace PosTech.PortFolio.Entities
{
    public class AtivoEntity : EntityBase
    {
        public TipoAtivo Tipo { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }

        public AtivoEntity(TipoAtivo tipo, string nome, string codigo)
        {
            Tipo = tipo;
            Nome = nome;
            Codigo = codigo;
        }
    }
}
