namespace HackathonConverter.Services.Interfaces;

public interface IChatGptService
{
    Task<List<string>> ExecuteAsync(List<string> source, CancellationToken cancellationToken = default);
}