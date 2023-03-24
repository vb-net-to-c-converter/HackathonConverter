using HackathonConverter.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace HackathonConverter.Services.Services
{
    public class FileProcessorService : IFileProcessorService
    {
        private readonly IArguments _arguments;
        private readonly ICopyProjectService _copyProjectService;
        private readonly IChatGptService _chatGptService;
        private readonly ILogger<FileProcessorService> _logger;

        public FileProcessorService(IArguments arguments, ICopyProjectService copyProjectService, IChatGptService chatGptService, ILogger<FileProcessorService> logger)
        {
            _arguments = arguments;
            _copyProjectService = copyProjectService;
            _chatGptService = chatGptService;
            _logger = logger;
        }

        public async Task ReadAndConvert(string filePath, CancellationToken cancellationToken)
        {
            try
            {
                var fileName = Path.Combine(_arguments.Path, filePath);
                
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(fileName))
                {
                    // Read the stream as a string, and write the string to the console.
                    var text = await sr.ReadToEndAsync();
                    
                    var converterVbList = await GetConverterCode(text, cancellationToken);

                    //Save to c# file
                    await SaveToFile(converterVbList, filePath);
                }
            }
            catch (IOException e)
            {
                _logger.LogError(e.Message, "The file could not be read");
            }
        }

        private Task<List<string>> GetConverterCode(string vbList, CancellationToken cancellationToken)
        {
            var lines = vbList.Split("\n").ToList();
            return _chatGptService.ExecuteAsync(lines, cancellationToken);
        }

        private async Task SaveToFile(List<string> fileDataList, string fileName)
        {
            // Write the string array to a new file 
            await using StreamWriter outputFile = new StreamWriter(Path.ChangeExtension(Path.Combine(_copyProjectService.GetNewBasePath()??"",fileName), ".cs"));
            foreach (string line in fileDataList)
                await outputFile.WriteLineAsync(line);

            await outputFile.FlushAsync();
        }

    }
}
