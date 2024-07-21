using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages.Ativo;
using PosTech.TechChallenge.Shared;

namespace PosTech.PortFolio.UseCases.Transacao
{
    public class RegistrarTransacaoVendaUseCase
    {
        private readonly TransacaoEntity Transacao;
        private readonly int _quantidadeAtivos;
        private readonly double _valorUnitario;
        private readonly InvestimentoEntity _saldoAtivo;

        public RegistrarTransacaoVendaUseCase(PortFolioEntity portFolio,
            AtivoEntity ativo, int quantidade, double preco,
            InvestimentoEntity saldoAtivo)
        {
            _quantidadeAtivos = quantidade;
            _valorUnitario = preco;
            _saldoAtivo = saldoAtivo;

            Transacao = new TransacaoEntity(portFolio, ativo, TipoTransacao.Venda, quantidade, preco, Guid.NewGuid().ToString(), DateTime.Now);
        }

        public TransacaoEntity FinalizarTransacao()
        {
            AssertionConcern.AssertArgumentMinValue(_quantidadeAtivos, _saldoAtivo.Quantidade,  ValidationMessages.MensagemSaldoAtivoInsuficiente);
            AssertionConcern.AssertArgumentMinValue(1, _quantidadeAtivos, ValidationMessages.MensagemQuantidadeAtivosInvalida);
            AssertionConcern.AssertDoublePositiveValue(_valorUnitario, ValidationMessages.MensagemValorAtivoInvalido);

            return Transacao;
        }
    }
}
