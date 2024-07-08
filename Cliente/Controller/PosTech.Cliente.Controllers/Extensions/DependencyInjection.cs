using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosTech.Cliente.DAO;
using PosTech.Cliente.Interfaces.Controller;

namespace PosTech.Cliente.Controllers.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCleanArchitectureControllers(this IServiceCollection services, IConfiguration configuration)
        {
            //adiciona controllers da clean arch
            services.AddScoped<IClienteController, ClienteController>();


            return services;
        }
    }
}
