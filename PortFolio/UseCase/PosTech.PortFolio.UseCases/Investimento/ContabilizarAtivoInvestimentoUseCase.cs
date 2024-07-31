using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.UseCases.Investimento
{
    public class ContabilizarAtivoInvestimentoUseCase
    {
        private List<TransacaoEntity> _transacoes;

        public ContabilizarAtivoInvestimentoUseCase(List<TransacaoEntity> transacoes)
        {
            _transacoes = transacoes;
        }

        public InvestimentoEntity CalcularQuantidadePorAtivo(AtivoEntity ativo)
        {
            var listagemPorAtivo = _transacoes?.Where(t => t.AtivoId == ativo.Id).ToList();
            int quantidadedeAtivos = 0;
            foreach (var entity in listagemPorAtivo)
            {
                if (entity.TipoTransacao == TipoTransacao.Compra)
                    quantidadedeAtivos += entity.Quantidade;
                else
                    quantidadedeAtivos -= entity.Quantidade;
            }

            InvestimentoEntity totalCalculado = new InvestimentoEntity(ativo, quantidadedeAtivos, 0);
            return totalCalculado;
        }

        public List<InvestimentoEntity> CalcularAtivos()
        {
            List<InvestimentoEntity> ret = new List<InvestimentoEntity>();
            var ativos = _transacoes.Select(t => t.Ativo).Distinct().ToList();
            foreach (AtivoEntity ativo in ativos)
            {
                var x = CalcularQuantidadePorAtivo(ativo);
                if (x != null)
                    ret.Add(x);
            }
            return ret;
        }
    }
}
