namespace HackathonConverter.Services.Interfaces
{
    public interface IProjectReader
    {
        Task ProcessAsync(CancellationToken stoppingToken);
    }
}
