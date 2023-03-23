using HackathonConverter;
using HackathonConverter.Services.Interfaces;
using HackathonConverter.Services.Services;
using ICopyProjectService = HackathonConverter.Services.Interfaces.ICopyProjectService;

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
            .AddSingleton<ICopyProjectService,CopyProjectService>()
            ;
    })
    .Build();

await host.RunAsync();

