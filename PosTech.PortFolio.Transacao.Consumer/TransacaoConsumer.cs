using MassTransit;
using PosTech.PortFolio.Entities;
using PosTech.PortFolio.Repository.Sql.Interface;

namespace PosTech.PortFolio.Transacao.Consumer
{
    public class TransacaoConsumer : IConsumer<TransacaoEntity>
    {
        private readonly ITransacaoRepository _repository;

        public TransacaoConsumer(ITransacaoRepository repository)
        {
            _repository = repository;
        }

        public Task Consume(ConsumeContext<TransacaoEntity> context)
        {
            switch (context.Message.TipoTransacao)
            {
                case TipoTransacao.Compra:
                    {
                        _repository.Incluir(context.Message);
                        //dispatch Atualizar Conta
                        break;
                    }
                case TipoTransacao.Venda:
                    {
                        _repository.Incluir(context.Message);
                        //dispatch Atualizar Saldo
                        break;
                    }
            }
            return Task.CompletedTask;
        }
    }
}
