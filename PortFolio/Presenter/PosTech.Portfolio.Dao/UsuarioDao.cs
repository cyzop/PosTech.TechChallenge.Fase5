namespace PosTech.PortFolio.DAO
{
    public class UsuarioDao
    {
        public string Id { get; private set; }
        public string? Nome { get; private set; }

        public string? Email { get; private set; }

        public UsuarioDao(string id, string? nome, string? email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public UsuarioDao(string id)
        {
            Id = id;
        }

        public void SetId(string id)
        {
            Id = id;
        }
    }
}