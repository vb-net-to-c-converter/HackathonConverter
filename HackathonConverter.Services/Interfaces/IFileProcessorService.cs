namespace HackathonConverter.Services.Interfaces;

public interface IFileProcessorService
{
    Task ReadAndConvert(string filePath, CancellationToken cancellationToken);
}