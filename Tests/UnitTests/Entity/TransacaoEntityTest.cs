﻿using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Tests.Fixtures;

namespace PosTech.PortFolio.Tests.UnitTests.Entity
{
    [Collection(nameof(TransacaoTestFixtureCollection))]
    public class TransacaoEntityTest
    {
        private readonly TransacaoTestFixture _fixture;

        public TransacaoEntityTest(TransacaoTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Teste unitario de validacao de Transação Financeira")]
        [Trait("Entity.Transacao", "Teste unitario de validacao de Transação Financeira")]
        public void ValidateEntity_Should_New_TransacaoEntity()
        {
            //Arrange
            var entidade = _fixture.GerarTransacaoEntity();

            //Act
            var act = entidade != null;

            //Assert
            Assert.True(act);
            Assert.Equal(typeof(TransacaoEntity), entidade?.GetType());
        }
    }
}
