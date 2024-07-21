using PosTech.PortFolio.Assertion;

namespace PosTech.PortFolio.Entities
{
    public class PortFolioEntity : EntityBase
    {
        public string ClienteId { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public PortFolioEntity(ClienteEntity cliente, string nome, string descricao, string id, DateTime data) : base (id, data)
        {
            ClienteId = cliente.Id;
            Cliente = cliente;
            Nome = nome;
            Descricao = descricao;

            Validate();
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentIsNull(Cliente, Messages.PortFolio.ValidationMessages.MensagemClienteVazio);
            AssertionConcern.AssertArgumentNotEmpty(Nome, Messages.PortFolio.ValidationMessages.MensagemNomeVazio);
        }
    }
}