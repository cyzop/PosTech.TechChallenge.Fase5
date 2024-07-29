namespace PosTech.PortFolio.Cliente.Api.Model
{
    public class UpdateClienteModel
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
    }
}
