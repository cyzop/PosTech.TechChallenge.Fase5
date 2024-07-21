using Bogus;
using PosTech.PortFolio.DAO;
using PosTech.PortFolio.Entities;

namespace PosTech.PortFolio.Api.Tests.fixtures
{
    public class AtivoTestFixture
    {
        private readonly Faker _faker;

        public AtivoTestFixture()
        {
            _faker = new Faker();
        }

        public AtivoDao GerarAtivoDao()
        {
            var identificador = _faker.Finance.Bic();
            var nome = _faker.Finance.AccountName();
            var tipoNumero = _faker.Random.Number(2);

            TipoAtivo enumTipo = (TipoAtivo)tipoNumero;

            return new AtivoDao() { Codigo = identificador, Nome = nome, Tipo = enumTipo.ToString() };
        }

        public AtivoEntity GerarAtivoEntity()
        {
            var codigo = _faker.Finance.Bic();
            var nome = _faker.Finance.AccountName();
            var tipoNumero = _faker.Random.Number(2);
            var id = Guid.NewGuid().ToString();
            var data = _faker.Date.Recent(10, DateTime.Now);

            TipoAtivo enumTipo = (TipoAtivo)tipoNumero;

            return new AtivoEntity(enumTipo, nome, codigo, id, data);
        }
    }
}
