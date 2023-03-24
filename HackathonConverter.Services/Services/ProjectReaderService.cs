using HackathonConverter.Services.Interfaces;
using System.Xml.Linq;

namespace HackathonConverter.Services.Services;

public class ProjectReaderService : IProjectReader
{
    private readonly IFileProcessorService _processorService;
    private readonly string _FilePath;

    public ProjectReaderService(IArguments arguments, IFileProcessorService processorService)
    {
        _processorService = processorService;
        _FilePath = arguments.Path;
    }

    public async Task ProcessAsync(CancellationToken stoppingToken)
    {
        // Check the cancellation token before starting the operation
        stoppingToken.ThrowIfCancellationRequested();

        var files = await GetFiles();
        var tasks = new List<Task>();
        foreach (var file in files)
        {
            tasks.Add(_processorService.ReadAndConvert(file, stoppingToken));
        }
        await Task.WhenAll(tasks);
    }

    private Task<List<string>> GetFiles()
    {
        //ToDo: break this out into more methods for easier reading
        var vbFileName = "";
        var itemList = new List<string>();

        try
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(_FilePath);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");


            //get VBProject name
            foreach (var file in dir.GetFiles())
            {
                if (file.Extension == ".vbproj")
                {
                    //done an equals for now. Needs to append this probably
                    vbFileName = file.FullName;
                    break;
                }
            }

            //get all vb file names we need
            XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";
            var vbprojXml = XDocument.Load(vbFileName);

            itemList = vbprojXml.Descendants(msbuild + "ItemGroup")
                .Elements(msbuild + "Compile")
                .Select(item => item.Attribute("Include")?.Value??"")
                .ToList();
            
            return Task.FromResult(itemList);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return Task.FromResult(itemList);
        }
    }
}