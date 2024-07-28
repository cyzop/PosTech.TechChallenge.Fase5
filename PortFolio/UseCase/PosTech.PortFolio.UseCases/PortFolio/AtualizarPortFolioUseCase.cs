using PosTech.PortFolio.Assertion;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.PortFolio;

namespace PosTech.PortFolio.UseCases.PortFolio
{
    public class AtualizarPortFolioUseCase
    {
        private PortFolioEntity _portFolio;
        private IEnumerable<PortFolioEntity> portFoliosUsuario;

        public AtualizarPortFolioUseCase(PortFolioEntity novoPortFolio, IEnumerable<PortFolioEntity> portFoliosUsuario)
        {
            _portFolio = novoPortFolio;
            this.portFoliosUsuario = portFoliosUsuario;
        }

        public PortFolioEntity VerificarPortFolio()
        {
            AssertionConcern.AssertArgumentNotEmpty(_portFolio.Nome, ValidationMessages.MensagemNomeVazio);

            //nome exclusivo
            var exist = portFoliosUsuario?
                .FirstOrDefault(p => p.Nome.Equals(_portFolio.Nome, StringComparison.InvariantCultureIgnoreCase)
                         && p.Id != _portFolio.Id);

            AssertionConcern.AssertArgumentIsNull(exist, ValidationMessages.MensagemPortFolioJaExistente);

            _portFolio.Id = Guid.NewGuid().ToString();

            return _portFolio;
        }
    }
}
