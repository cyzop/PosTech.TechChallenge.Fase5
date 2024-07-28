using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PortFolio.PortFolioWeb.Server.Services;
using PosTech.PortFolioWeb.Server.Data;
using PosTech.PortFolioWeb.Server.Models;
using PosTech.PortFolioWeb.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddTransient<AtivosAPI>();
builder.Services.AddTransient<PortfoliosApi>();
builder.Services.AddTransient<TransacaoAPI>();
builder.Services.AddTransient<CotacaoAtivosAPI>();
builder.Services.AddTransient<InvestimentoAPI>();
builder.Services.AddTransient<ClienteAPI>();


builder.Services.AddHttpClient("AtivoAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["AtivoAPI:Url"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddHttpClient("PortFolioAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PortFolioAPI:Url"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddHttpClient("TransacaoAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["TransacaoAPI:Url"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddHttpClient("CotacaoAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CotacaoAPI:Url"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddHttpClient("InvestimentoAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["InvestimentoAPI:Url"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddHttpClient("ClienteAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ClienteAPI:Url"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
