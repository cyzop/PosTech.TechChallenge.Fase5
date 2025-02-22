﻿using PosTech.PortFolio.Adapter;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.UseCases.PortFolio;

namespace PosTech.PortFolio.Controllers
{
    public class PortFolioController : IPortFolioController
    {
        readonly IPortFolioGateway _gateway;
        readonly IUsuarioGateway _usuarioGateway;

        public PortFolioController(IPortFolioGateway gateway, IUsuarioGateway usuarioGateway)
        {
            _gateway = gateway;
            _usuarioGateway = usuarioGateway;
        }

        public IEnumerable<PortFolioDao> ListarPorUsuario(string userMail)
        {
            var usuario = _usuarioGateway.ObterPorEmail(userMail);
            
            if (usuario == null)
                return new List<PortFolioDao>();

            return _gateway.ObterPorUsuario(usuario.Id)?.Select(e => PortFolioDaoAdapter.GetDaoFromEntity(e));
        }

        public IEnumerable<PortFolioDao> ListarTodos()
        {
            return _gateway.ObterTodos()?.Select(e => PortFolioDaoAdapter.GetDaoFromEntity(e));
        }

        public PortFolioDao ObterPorId(string id)
        {
            return PortFolioDaoAdapter.GetDaoFromEntity(_gateway.ObterPorId(id));
        }

        public PortFolioDao RegistrarPortFolio(PortFolioDao portFolioDao)
        {
            var cliente = _usuarioGateway.ObterPorId(portFolioDao.Usuario.Id);
            var portFoliosUsuario = _gateway.ObterPorUsuario(portFolioDao.Usuario.Id);

            var novoPortFolio = new PortFolioEntity(cliente, portFolioDao.Nome, portFolioDao.Descricao, Guid.NewGuid().ToString(), DateTime.Now);

            //PortFolio use case
            RegistrarPortFolioUseCase registroPortFolio = new RegistrarPortFolioUseCase(novoPortFolio, portFoliosUsuario);
            var portFolio = registroPortFolio.VerificarPortFolio();

            //transacao gateway (registrar a transacao)
            _gateway.RegistrarPortFolio(portFolio);

            return PortFolioDaoAdapter.GetDaoFromEntity(portFolio);
        }

        public PortFolioDao AtualizarPortFolio(PortFolioDao portFolioDao)
        {
            var portFoliosUsuario = _gateway.ObterPorUsuario(portFolioDao.Usuario.Id);
            var portFolioDb = _gateway.ObterPorId(portFolioDao.Id);

            var portFolioAtualizar = new PortFolioEntity(portFolioDb.Cliente, 
                portFolioDao.Nome, 
                portFolioDao.Descricao, 
                portFolioDb.Id, 
                portFolioDb.DataCriacao);

            //PortFolio use case
            AtualizarPortFolioUseCase registroPortFolio = new AtualizarPortFolioUseCase(portFolioAtualizar, portFoliosUsuario);
            var portFolio = registroPortFolio.VerificarPortFolio();

            portFolioDb.Nome = portFolioAtualizar.Nome;
            portFolioDb.Descricao = portFolioAtualizar.Descricao;

            //transacao gateway (registrar a transacao)
            _gateway.AtualizarPortFolio(portFolioDb);

            return PortFolioDaoAdapter.GetDaoFromEntity(portFolioAtualizar);
        }
    }
}