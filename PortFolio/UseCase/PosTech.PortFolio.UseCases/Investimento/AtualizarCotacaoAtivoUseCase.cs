using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.UseCases.Investimento
{
    public class AtualizarCotacaoAtivoUseCase
    {
        private readonly List<InvestimentoEntity> _investimentos;
        private readonly List<CotacaoAtivoEntity> _cotacoes;
        public AtualizarCotacaoAtivoUseCase(List<InvestimentoEntity> investimentos, List<CotacaoAtivoEntity> cotacoes)
        {
            _investimentos = investimentos;
            _cotacoes = cotacoes;
        }

        public List<InvestimentoEntity> AtualizarCotacaoInvestimentos()
        {
            return _investimentos.Select(x =>
            new InvestimentoEntity(
                x.Ativo,
                x.Quantidade,
                (x.Quantidade * _cotacoes.FirstOrDefault(a => a.Codigo == x.Ativo.Codigo)?.Cotacao)??0)).ToList();
        } 

        private InvestimentoEntity TotalizarValorAtivo(InvestimentoEntity x)
        {
            var ativoContacao = _cotacoes.FirstOrDefault(a => a.Codigo == x.Ativo.Codigo);
            var valorInvestimento = ativoContacao != null ? x.Quantidade * ativoContacao.Cotacao : 0;

            return new InvestimentoEntity(x.Ativo, x.Quantidade, valorInvestimento);
        }
    }
}
