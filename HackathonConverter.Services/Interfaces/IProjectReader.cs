namespace HackathonConverter.Services.Interfaces
{
    public interface IProjectReader
    {
        public Task ProcessAsync(CancellationToken stoppingToken);
        public Task<List<string>> GetFiles();

    }
}
