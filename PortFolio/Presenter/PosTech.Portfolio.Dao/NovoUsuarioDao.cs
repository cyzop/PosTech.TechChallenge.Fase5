
namespace PosTech.PortFolio.DAO
{ 
    public class NovoUsuarioDao : UsuarioDao
    {
        public string Senha { get; private set; }

        public NovoUsuarioDao(string nome, string email, string senha):base(string.Empty, nome, email)
        {
            Senha = senha;
        }

        public NovoUsuarioDao(string id, string nome, string email, string senha) : base(id, nome, email)
        {
            Senha = senha;
        }

        public void SetSenha(string senha)
        {
            this.Senha = senha;
        }
     }
}
