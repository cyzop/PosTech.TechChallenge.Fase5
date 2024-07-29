
namespace PosTech.PortFolio.DAO
{ 
    public class NovoUsuarioDao : UsuarioDao
    {
        public NovoUsuarioDao(string nome, string email):base(string.Empty, nome, email)
        {
        }

        public NovoUsuarioDao(string id, string nome, string email) : base(id, nome, email)
        {
        }
     }
}
