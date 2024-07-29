using Bogus;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PosTech.PortFolio.Api.Tests.fixtures;
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

            return new TransacaoDao()
            {
                TipoTransacao = enumTipoTransacao.ToString(),
                DataTransacao = DateTime.Now,
                AtivoTransacao = new AtivoTransacaoDao() { 
                    Nome = nome, 
                    Codigo = identificador, 
                    Preco = preco, 
                    Quantidade = quantidade,
                    Tipo = enumTipoAtivo.ToString()
                },
                PortFolio = new PortFolioTestFixture().GerarPortFolioDao()
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
