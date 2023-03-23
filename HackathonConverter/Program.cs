using System.Text.Json;
using HackathonConverter;
using HackathonConverter.Services.Interfaces;
using HackathonConverter.Services.Models;
using HackathonConverter.Services.Services;
using HackathonConverter.Services.Utils;
using Refit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Add Configuration settings bind to options
        services
            .AddOptions<ChatGPTSettings>().Bind(context.Configuration.GetSection("ChatGPTSettings"))
            ;

        services
            .AddSingleton<IArguments>(_=>new ArgumentsService(args))
            .AddHostedService<Worker>()
            // Add all services as Singletons bellow
            ;

        AddRefitClient(services, context.Configuration);
    })
    .Build();

await host.RunAsync();

void AddRefitClient(IServiceCollection services, IConfiguration configuration)
{
    services
        .AddRefitClient<IChatGpt>(new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                { PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance })
        })
        .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration.GetValue<string>("ChatGPTSettings:BaseUrl")))
        ;
}
