using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Messages;
using PosTech.TechChallenge.Shared;

namespace PosTech.PortFolio.UseCases
{
    public class RegistrarTransacaoCompraUseCase
    {
        private readonly TransacaoEntity Transacao;
        private readonly int _quantidadeAtivos;
        private readonly double _valorUnitario;

        public RegistrarTransacaoCompraUseCase(PortFolioEntity portFolio,
            AtivoEntity ativo, int quantidade, double preco)
        {
            _quantidadeAtivos = quantidade;
            _valorUnitario = preco;

            Transacao = new TransacaoEntity(TipoTransacao.Compra, portFolio, ativo);
        }

        public TransacaoEntity FinalizarTransacao()
        {
            AssertionConcern.AssertArgumentMinValue(1, _quantidadeAtivos, ValidationMessages.MensagemQuantidadeAtivosInvalida);
            Transacao.SetQuantidade(_quantidadeAtivos);

            AssertionConcern.AssertDoublePositiveValue(_valorUnitario, ValidationMessages.MensagemValorAtivoInvalido);
            Transacao.SetPreco(_valorUnitario);

            return Transacao;
        }
    }
}
