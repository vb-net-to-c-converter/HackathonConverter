using HackathonConverter.Services.Interfaces;
using HackathonConverter.Services.Services;
using Microsoft.Extensions.Logging;

namespace HackathonConverter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IArguments _arguments;

        public Worker(ILogger<Worker> logger, IArguments arguments)
        {
            _logger = logger;
            _arguments = arguments;
            logger.LogDebug($"Path is the ------------ {arguments.Path} ---------------");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //todo: update while to be until all vikram tasks are done
            //instead of while - my Task method here
            //  - don't finish until Vikrams methods are done
            while (!stoppingToken.IsCancellationRequested)
            {
               
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                await Task.Delay(6000000, stoppingToken);
            }
        }
    }
}