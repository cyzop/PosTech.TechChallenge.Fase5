using PosTech.PortFolio.Assertion;

namespace PosTech.PortFolio.Entities
{
    public class ClienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public string? Senha { get; set; }

        public ClienteEntity() { }
        public ClienteEntity(string nome, string email, string? senha, string id, DateTime dataCriacao):base(id, dataCriacao)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentDate(base.DataCriacao, DateTime.MinValue, DateTime.Now, Messages.Cliente.ValidationMessages.MensagemDataCriacaoInvalida);
            AssertionConcern.AssertArgumentNotEmpty(Nome, Messages.Cliente.ValidationMessages.MensagemNomeVazio);
            AssertionConcern.AssertArgumentNotEmpty(Email, Messages.Cliente.ValidationMessages.MensagemEmailVazio);
            AssertionConcern.AssertArgumentNotEmpty(Senha, Messages.Cliente.ValidationMessages.MensagemSenhaVazia);
        }
    }
}
