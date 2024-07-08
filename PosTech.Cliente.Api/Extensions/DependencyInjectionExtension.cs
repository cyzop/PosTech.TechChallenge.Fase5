using PosTech.Cliente.DAO;
using PosTech.Cliente.Gateways;
using PosTech.Cliente.Interfaces.Controller;
using PosTech.Cliente.Interfaces.Gateways;
using PosTech.Cliente.Interfaces.Repositories;
using PosTech.Cliente.Repository.NoSql;

namespace PosTech.Cliente.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();

            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IClienteGateway, ClienteGateway>();

            services.AddScoped<IClienteController, ClienteController>();

            return services;
        }
    }
}
