using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SweetCakeFrontend.Provider;
using SweetCakeFrontend.Services;

namespace SweetCakeFrontend;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        // read appsettings from appsettings.json
        builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        builder.Services.AddAuthorizationCore();


        //Register Service: DI
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<HomeService>();
        builder.Services.AddScoped<AccountService>();
        builder.Services.AddScoped<ProductService>();
        builder.Services.AddScoped<StatisticsService>();
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<ProductSizeService>();
        builder.Services.AddScoped<ProductColorService>();
        builder.Services.AddScoped<OrderService>();

        builder.Services.AddScoped<JwtAuthenticationStateProvider>();


        builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddBlazorBootstrap();
        await builder.Build().RunAsync();
    }
}
