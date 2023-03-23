using HackathonConverter.Services.Interfaces;

namespace HackathonConverter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, IArguments arguments)
        {
            _logger = logger;
            _logger.LogDebug($"Path is the ------------ {arguments.Path} ---------------");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                await Task.Delay(6000000, stoppingToken);
            }
        }
    }
}