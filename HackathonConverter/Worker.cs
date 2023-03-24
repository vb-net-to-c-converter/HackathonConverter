using HackathonConverter.Services.Interfaces;

namespace HackathonConverter
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProjectReader _projectReader;
        private readonly ICopyProjectService _copyProjectService;

        public Worker(ILogger<Worker> logger, IProjectReader projectReader, ICopyProjectService copyProjectService)
        {
            _logger = logger;
            _projectReader = projectReader;
            _copyProjectService = copyProjectService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Start converting");
            _copyProjectService.CopySourceProjectExcludingVbFiles();
            await _projectReader.ProcessAsync(stoppingToken);
            _logger.LogInformation("Conversion complete, close the window");
        }
    }
}