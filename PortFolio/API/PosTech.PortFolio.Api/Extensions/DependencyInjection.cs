using PosTech.PortFolio.Controllers;
using PosTech.PortFolio.Gateways;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;
using PosTech.PortFolio.Repository.Sql;
using PosTech.PortFolio.Repository.Sql.Interface;

namespace PosTech.PortFolio.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            //Ativo
            services.AddScoped<IAtivoController, AtivoController>();
            services.AddScoped<IAtivoRepository, AtivoRepository>();
            services.AddScoped<IAtivoGateway, AtivoGateway>();

            //PortFolio
            services.AddScoped<IPortFolioRepository, PortFolioRepository>();
            services.AddScoped<IPortFolioGateway, PortFolioGateway>();
            services.AddScoped<IPortFolioController, PortFolioController>();

            //Transacao
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<ITransacaoGateway, TransacaoGateway>();
            services.AddScoped<ITransacaoController, TransacaoController>();

            //Usuario
            services.AddScoped<IClienteController, ClienteController>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioGateway, UsuarioGateway>();


            return services;
        }
    }
}
