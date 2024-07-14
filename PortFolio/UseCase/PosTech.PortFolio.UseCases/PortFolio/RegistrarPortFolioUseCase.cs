using PosTech.Cliente.Messages;
using PosTech.PortFolio.Entities;
using PosTech.TechChallenge.Shared;

namespace PosTech.PortFolio.UseCases.PortFolio
{
    public class RegistrarPortFolioUseCase
    {
        private PortFolioEntity _novoPortFolio;
        private IEnumerable<PortFolioEntity> portFoliosUsuario;

        public RegistrarPortFolioUseCase(PortFolioEntity novoPortFolio, IEnumerable<PortFolioEntity> portFoliosUsuario)
        {
            _novoPortFolio = novoPortFolio;
            portFoliosUsuario = portFoliosUsuario;
        }

        public PortFolioEntity VerificarPortFolio()
        {
            AssertionConcern.AssertArgumentNotEmpty(_novoPortFolio.Nome, ValidationMessages.MensagemNomeVazio);

            var exist = portFoliosUsuario?.First(p => p.Nome.Equals(_novoPortFolio.Nome, StringComparison.InvariantCultureIgnoreCase));

            AssertionConcern.AssertArgumentIsNull(exist, ValidationMessages.MensagemPortFolioJaExistente);

            _novoPortFolio.Id = Guid.NewGuid().ToString();

            return _novoPortFolio;
        }
    }
}
