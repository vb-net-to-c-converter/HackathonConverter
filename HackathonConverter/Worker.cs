using HackathonConverter.Services.Interfaces;
using HackathonConverter.Services.Services;
using Microsoft.Extensions.Logging;

namespace HackathonConverter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IArguments _arguments;
        private readonly IProjectReader _service;

        public Worker(ILogger<Worker> logger, IArguments arguments)
        {
            _logger = logger;
            _arguments = arguments;
            _service = new ProjectReaderService(_arguments);
            logger.LogDebug($"Path is the ------------ {arguments.Path} ---------------");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            bool isProjectReaderDone = false;

            while (!stoppingToken.IsCancellationRequested && !isProjectReaderDone)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _service.ProcessAsync(stoppingToken);
                isProjectReaderDone = true;

                await Task.Delay(6000000, stoppingToken);
            }

            _logger.LogInformation("Worker stopped at: {time}", DateTimeOffset.Now);

        }
    }
}