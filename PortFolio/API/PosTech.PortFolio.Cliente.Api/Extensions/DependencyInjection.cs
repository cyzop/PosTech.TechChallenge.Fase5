using PosTech.PortFolio.Controllers;
using PosTech.PortFolio.Gateways;
using PosTech.PortFolio.Interfaces.Controller;
using PosTech.PortFolio.Interfaces.Gateways;
using PosTech.PortFolio.Interfaces.Repositories;
using PosTech.PortFolio.Repository.Sql;

namespace PosTech.PortFolio.Cliente.Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            //Usuario
            services.AddScoped<IClienteController, ClienteController>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioGateway, UsuarioGateway>();

            return services;
        }
    }
}
