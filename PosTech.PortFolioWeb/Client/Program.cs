using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PosTech.PortFolioWeb.Client;
using PosTech.PortFolioWeb.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("PosTech.PortFolioWeb.ServerAPI", 
                                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services
    .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient("PosTech.PortFolioWeb.ServerAPI"));

builder.Services.AddScoped<UsuarioService>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
