using MassTransit;
using Microsoft.EntityFrameworkCore;
using PosTech.PortFolio.Repository.Sql;
using PosTech.PortFolio.Repository.Sql.Interface;
using PosTech.PortFolio.Transacao.Consumer;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureAppConfiguration(config =>
     {
         //var conexao = Environment.GetEnvironmentVariable("postechazappconfiguration") ?? string.Empty;
         //config.AddAzureAppConfiguration(conexao);
         config.AddAzureAppConfiguration(options =>
         {
             options.Connect("Endpoint=https://emiliocelso-cfg.azconfig.io;Id=8OLu-le-s0:PEVnYMv4lByTYO0ro9J3;Secret=ur4lK23LafsPx1vv9GAxz9dtjTNBTgiPMLg+rwtkAQY=\"");
         });
     })
    .ConfigureServices((hostcontext, services) =>
    {
        var configuration = hostcontext.Configuration;

        var conexao = configuration["postechcadpac:masstransit:azurebus"] ?? string.Empty;
        var filatransacao = configuration.GetSection("TransacaoAzBus")["QueueName"] ?? string.Empty;

        services.AddHostedService<Worker>();

        services.AddScoped<ITransacaoRepository, TransacaoRepository>();

        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(config.GetConnectionString("ConnectionString"));
            options.UseLazyLoadingProxies();
        }, ServiceLifetime.Scoped);

        services.AddMassTransit(x =>
        {
            x.UsingAzureServiceBus((context, cfg) =>
            {
                cfg.Host(conexao);

                cfg.ReceiveEndpoint(filatransacao, e =>
                {
                    e.ConfigureConsumer<TransacaoConsumer>(context);
                });
            });

            x.AddConsumer<TransacaoConsumer>();
        });
    })
    .Build();

host.Run();
