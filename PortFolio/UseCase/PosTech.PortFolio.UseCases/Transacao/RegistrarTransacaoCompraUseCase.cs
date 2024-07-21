using PosTech.PortFolio.Entities;
using PosTech.TechChallenge.Shared;

namespace PosTech.PortFolio.UseCases.Transacao
{
    public class RegistrarTransacaoCompraUseCase
    {
        private readonly TransacaoEntity Transacao;
        private readonly int _quantidadeAtivos;
        private readonly double _valorUnitario;

        public RegistrarTransacaoCompraUseCase(PortFolioEntity portFolio,
            AtivoEntity ativo, int quantidade, double preco)
        {
            AssertionConcern.AssertArgumentNotNull(portFolio, Messages.PortFolio.ValidationMessages.MensagemPortFolioNaoEncontrado);

            AssertionConcern.AssertArgumentNotNull(ativo, Messages.Ativo.ValidationMessages.MensagemAtivoNaoEncontrado);

            _quantidadeAtivos = quantidade;
            _valorUnitario = preco;

            Transacao = new TransacaoEntity(portFolio, ativo, TipoTransacao.Compra, quantidade, preco, Guid.NewGuid().ToString(), DateTime.Now);
        }

        public TransacaoEntity FinalizarTransacao()
        {
            AssertionConcern.AssertArgumentMinValue(1, _quantidadeAtivos, Messages.Ativo.ValidationMessages.MensagemQuantidadeAtivosInvalida);
            AssertionConcern.AssertDoublePositiveValue(_valorUnitario, Messages.Ativo.ValidationMessages.MensagemValorAtivoInvalido);
            return Transacao;
        }
    }
}
