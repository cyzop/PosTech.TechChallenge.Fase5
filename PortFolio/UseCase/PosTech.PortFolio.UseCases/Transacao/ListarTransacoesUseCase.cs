using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.UseCases.Transacao
{
    public class ListarTransacoesUseCase
    {
        private readonly IEnumerable<TransacaoEntity> transacoes;
        public ListarTransacoesUseCase(IEnumerable<TransacaoEntity> transacoes)
        {
            this.transacoes = transacoes;
        }

        public IEnumerable<TransacaoEntity> Listar()
        {
            return transacoes.OrderByDescending(x=>x.DataCriacao).ToList();
        }
    }
}
