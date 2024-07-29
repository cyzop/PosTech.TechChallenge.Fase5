using PosTech.PortFolio.Assertion;

namespace PosTech.PortFolio.Entities
{
    public class ClienteEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public ClienteEntity() { }
        public ClienteEntity(string nome, string email, string id, DateTime dataCriacao):base(id, dataCriacao)
        {
            Nome = nome;
            Email = email;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentDate(base.DataCriacao, DateTime.MinValue, DateTime.Now, Messages.Cliente.ValidationMessages.MensagemDataCriacaoInvalida);
            AssertionConcern.AssertArgumentNotEmpty(Nome, Messages.Cliente.ValidationMessages.MensagemNomeVazio);
            AssertionConcern.AssertArgumentNotEmpty(Email, Messages.Cliente.ValidationMessages.MensagemEmailVazio);
        }

        public void SetNome(string nome)
        {
            Nome = nome.Trim();
        }
    }
}
