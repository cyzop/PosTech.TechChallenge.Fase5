using Microsoft.EntityFrameworkCore;
using PosTech.PortFolio.Api.Extensions;
using PosTech.PortFolio.Repository.Sql;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(config.GetConnectionString("ConnectionString"));
    options.UseLazyLoadingProxies();
}, ServiceLifetime.Scoped);

builder.Host.ConfigureServices(services =>
{
    services.AddDependencyInjection(config);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "PortFolioApiPolicy",
        policy =>
        {
            policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseCors("PortFolioApiPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
