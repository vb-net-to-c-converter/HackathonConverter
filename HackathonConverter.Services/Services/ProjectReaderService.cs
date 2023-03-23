using HackathonConverter.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace HackathonConverter.Services.Services;

public class ProjectReaderService : IProjectReader
{
    private readonly IArguments _arguments;
    private readonly string _FilePath;

    public List<string> Projects { get; set; } = new List<string>();

    public ProjectReaderService(IArguments arguments)
    {
        _arguments = arguments;
        _FilePath = arguments.Path.ToString();
    }

    public async Task ProcessAsync(CancellationToken stoppingToken)
    {
        // Check the cancellation token before starting the operation
        stoppingToken.ThrowIfCancellationRequested();

        List<string> files = await GetFiles();

        foreach (string file in files)
        {
            //_logger.LogInformation("Filename: {filename}", file.ToString());
            //todo: vikram tasks here?
            Console.WriteLine("Filename: {0}", file.ToString());
        }
    }

    public Task<List<string>> GetFiles()
    {
        //ToDo: break this out into more methods for easier reading
        string vbFileName = "";
        List<string> itemList = new List<string>();

        try
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(_FilePath);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");


            //get VBProject name
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Extension == ".vbproj")
                {
                    //done an equals for now. Needs to append this probably
                    vbFileName = file.FullName.ToString();
                    break;
                }
            }

            //get all vb file names we need
            XNamespace msbuild = "http://schemas.microsoft.com/developer/msbuild/2003";
            XDocument vbprojXml = XDocument.Load(vbFileName);

            itemList = vbprojXml.Descendants(msbuild + "ItemGroup")
                .Elements(msbuild + "Compile")
                .Select(item => item.Attribute("Include").Value)
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