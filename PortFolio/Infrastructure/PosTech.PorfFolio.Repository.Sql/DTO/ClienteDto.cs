namespace PosTech.PortFolio.Repository.Sql.DTO
{
    public class ClienteDto
    {
        public string Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }

        
    }
}
