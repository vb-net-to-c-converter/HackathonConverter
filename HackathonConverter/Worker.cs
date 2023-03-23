using HackathonConverter.Services.Interfaces;

namespace HackathonConverter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;


        public Worker(ILogger<Worker> logger, ICopyProjectService copyProjectService)
        {
            _logger = logger;
            copyProjectService.CopySourceProjectExcludingVbFiles();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}