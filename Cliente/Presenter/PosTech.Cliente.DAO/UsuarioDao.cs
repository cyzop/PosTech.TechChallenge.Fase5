using System.Xml;

namespace PosTech.Cliente.DAO
{
    public class UsuarioDao
    {
        public string Id { get; private set; }
        public string Nome { get; }
        public string Email { get; }

        public UsuarioDao(string id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public void SetId(string id)
        { 
            Id = id; 
        }
    }
}
