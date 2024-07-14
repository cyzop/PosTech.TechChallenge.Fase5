namespace PosTech.PortFolio.Entities
{
    public class ClienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public string? Senha { get; set; }
    }
}
