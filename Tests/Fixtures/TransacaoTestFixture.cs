using Bogus;
using Bogus.DataSets;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Tests.Fixtures
{
    public class TransacaoTestFixture
    {
        private readonly Faker _faker;

        public TransacaoTestFixture()
        {
            _faker = new Faker();
        }

        public AtivoTransacaoDao GerarAtivoTransacaoDao(AtivoTransacaoDao ativo, int quantidade)
        {
            return new AtivoTransacaoDao()
            {
                Nome = ativo.Nome,
                Codigo = ativo.Codigo,
                Preco = ativo.Preco,
                Quantidade = quantidade,
                Tipo = ativo.Tipo
            };
        }
        public TransacaoDao GerarTransacaoVendaDao(PortFolioDao portFolio, AtivoTransacaoDao ativo, int quantidade)
        {
            return GetTransacaoDao(TipoTransacao.Venda,
                new AtivoTransacaoDao()
                {
                    Nome = ativo.Nome,
                    Codigo = ativo.Codigo,
                    Preco = ativo.Preco,
                    Quantidade = quantidade,
                    Tipo = ativo.Tipo
                },
                portFolio);
        }
        public TransacaoDao GerarTransacaoDao()
        {
            var identificador = _faker.Finance.Bic();
            var nome = _faker.Finance.AccountName();
            var preco = _faker.Random.Double(20);
            var quantidade = _faker.Random.Int(100);

            var tipoTransacao = _faker.Random.Number(1);
            TipoTransacao enumTipoTransacao = (TipoTransacao)tipoTransacao;
            var tipoAtivo = _faker.Random.Number(2);
            TipoAtivo enumTipoAtivo = (TipoAtivo)tipoAtivo;

            return GetTransacaoDao(enumTipoTransacao,
                new AtivoTransacaoDao()
                {
                    Nome = nome,
                    Codigo = identificador,
                    Preco = preco,
                    Quantidade = quantidade,
                    Tipo = enumTipoAtivo.ToString()
                },
                new PortFolioTestFixture().GerarPortFolioDao());
        }

        private TransacaoDao GetTransacaoDao(TipoTransacao tipoTransacao, AtivoTransacaoDao ativo, PortFolioDao portfolio)
        {
            return new TransacaoDao()
            {
                TipoTransacao = tipoTransacao.ToString(),
                DataTransacao = DateTime.Now,
                AtivoTransacao = ativo,
                PortFolio = portfolio
            };
        }

        public TransacaoEntity GerarTransacaoEntity()
        {
            var identificador = _faker.Finance.Bic();
            var nome = _faker.Finance.AccountName();
            var preco = _faker.Random.Double(20);
            var quantidade = _faker.Random.Int(100);

            var tipoTransacao = _faker.Random.Number(1);
            TipoTransacao enumTipoTransacao = (TipoTransacao)tipoTransacao;
            var tipoAtivo = _faker.Random.Number(2);
            TipoAtivo enumTipoAtivo = (TipoAtivo)tipoAtivo;

            return new TransacaoEntity()
            {
                TipoTransacao = enumTipoTransacao,
                DataCriacao = DateTime.Now,
                Ativo = new AtivoTestFixture().GerarAtivoEntity(),
                PortFolio = new PortFolioTestFixture().GerarPortFolioEntity()
            };
        }
    }
}
