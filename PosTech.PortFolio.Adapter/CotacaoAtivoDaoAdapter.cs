using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Adapter
{
    public static class CotacaoAtivoDaoAdapter
    {
        public static CotacaoAtivoDao GetDaoFromEntity(CotacaoAtivoEntity entity)
        {
            return new CotacaoAtivoDao()
            {
                Codigo = entity.Codigo,
                DataCotacao = entity.DataCotacao,
                Nome = entity.Nome,
                Preco = entity.Cotacao,
                Tipo = entity.Tipo.ToString()
            };
        }
    }
}
