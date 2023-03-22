using HackathonConverter;
using HackathonConverter.Services.Interfaces;
using HackathonConverter.Services.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Add Configuration settings bind to options
        //services
        //    .AddOptions<>().Bind(context.Configuration.GetSection(""))
        //    ;
        
        services
            .AddSingleton<IArguments>(_=>new ArgumentsService(args))
            .AddHostedService<Worker>()
            // Add all services as Singletons bellow
            ;
    })
    .Build();

await host.RunAsync();

