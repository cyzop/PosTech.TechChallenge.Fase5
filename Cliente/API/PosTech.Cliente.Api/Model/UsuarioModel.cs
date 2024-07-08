namespace PosTech.Cliente.Api.Model
{
    public class UsuarioModel
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
