namespace EventHorizon.Blazor.Dynamic.Scripting
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using EventHorizon.Blazor.Dynamic.Scripting.Pages;
    using EventHorizon.Blazor.Dynamic.Scripting.Services;
    using EventHorizon.Blazor.Dynamic.Scripting.Impl;
    using MediatR;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddMediatR(
                    typeof(Program)
                );
            builder.Services.AddSingleton<IClientInterop, ClientInteropImplementation>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<ScriptDllClient>(client => client.BaseAddress = new Uri("http://localhost:5000"));

            await builder.Build().RunAsync();
        }
    }
}
