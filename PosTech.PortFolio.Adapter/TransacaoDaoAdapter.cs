using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Adapter
{
    public static class TransacaoDaoAdapter
    {
        public static TransacaoDao GetDaoFromEntity(TransacaoEntity entity)
        {
            if (entity == null)
                return null;

            return new TransacaoDao
            {
                Id = entity.Id,
                DataTransacao = entity.DataCriacao,
                TipoTransacao = entity.TipoTransacao.ToString(),
                PortFolio = PortFolioDaoAdapter.GetDaoFromEntity(entity.PortFolio),
                AtivoTransacao = new AtivoTransacaoDao()
                {
                    Codigo = entity.Ativo.Codigo,
                    Nome = entity.Ativo.Nome,
                    Quantidade = entity.Quantidade,
                    Preco = entity.Preco,
                }
            };
        }
    }
}
