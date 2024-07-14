using PosTech.Cliente.Messages;
using PosTech.TechChallenge.Shared;

namespace PosTech.Cliente.Entities
{
    public class UsuarioEntity : EntityBase
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }


        public UsuarioEntity(string id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;

            ValidadeEntity();
        }

        public override void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, ValidationMessages.MensagemNomeVazio);
            
            AssertionConcern.AssertArgumentNotEmpty(Email, ValidationMessages.MensagemEmailVazio);
            AssertionConcern.AssertArgumentEmailIsValid(Email, ValidationMessages.MensagemEmailInvalido);

            AssertionConcern.AssertArgumentNotEmpty(Senha, ValidationMessages.MensagemSenhaVazia);
        }

        public void SetSenha(string senha)
        {
            this.Senha = senha;
        }

        public void SetId(string id)
        {
            this.Id = id;
        }
    }
}