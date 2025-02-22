﻿using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.PortFolio;
using PosTech.TechChallenge.Shared;

namespace PosTech.PortFolio.UseCases.PortFolio
{
    public class RegistrarPortFolioUseCase
    {
        private PortFolioEntity _novoPortFolio;
        private IEnumerable<PortFolioEntity> _portFoliosUsuario;

        public RegistrarPortFolioUseCase(PortFolioEntity novoPortFolio, IEnumerable<PortFolioEntity> portFoliosUsuario)
        {
            _novoPortFolio = novoPortFolio;
            _portFoliosUsuario = portFoliosUsuario;
        }

        public PortFolioEntity VerificarPortFolio()
        {
            AssertionConcern.AssertArgumentNotEmpty(_novoPortFolio.Nome, ValidationMessages.MensagemNomeVazio);

            var exist = _portFoliosUsuario?.FirstOrDefault(p => p.Nome.Equals(_novoPortFolio.Nome, StringComparison.InvariantCultureIgnoreCase));

            AssertionConcern.AssertArgumentIsNull(exist, ValidationMessages.MensagemPortFolioJaExistente);

            _novoPortFolio.Id = Guid.NewGuid().ToString();

            return _novoPortFolio;
        }
    }
}
