using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonConverter.Services.Interfaces;

namespace HackathonConverter.Services.Services;

public class CopyProjectService : ICopyProjectService
{
    private readonly IArguments _arguments;

    public CopyProjectService(IArguments arguments)
    {
        _arguments = arguments;
    }
    public void CopySourceProjectExcludingVbFiles()
    {
        var parentFolder = Directory.GetParent(_arguments.Path);
        var targetFolder = Path.Combine(parentFolder.FullName,$"{new System.IO.DirectoryInfo(_arguments.Path).Name}_c#");
        CopyDirectory(_arguments.Path, targetFolder, true);
        RemoveVBSourceFiles(targetFolder);
    }

    public string? GetNewBasePath()
    {
        var parentFolder = Directory.GetParent(_arguments.Path);
        var targetFolder = Path.Combine(parentFolder.FullName, $"{new System.IO.DirectoryInfo(_arguments.Path).Name}_c#");
        var dir = new DirectoryInfo(targetFolder);
        return (!dir.Exists) ? null : targetFolder;
        
    }
    private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
    {
        // Get information about the source directory
        var dir = new DirectoryInfo(sourceDir);

        // Check if the source directory exists
        if (!dir.Exists) return;

        var dirs = dir.GetDirectories();

        // remove destination directory and contents if exists
        if (Directory.Exists(destinationDir))
        {
            Directory.Delete(destinationDir, true);

        }
        // Create the destination directory
        Directory.CreateDirectory(destinationDir);

        // Get the files in the source directory and copy to the destination directory
        foreach (var file in dir.GetFiles())
        {
            var targetFilePath = Path.Combine(destinationDir, file.Name);
            file.CopyTo(targetFilePath);
        }

        // If recursive and copying subdirectories, recursively call this method
        if (recursive)
            foreach (DirectoryInfo subDir in dirs)
            {
                var newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                CopyDirectory(subDir.FullName, newDestinationDir, true);
            }
    }

    private void RemoveVBSourceFiles(string targetFolder)
    {
        foreach (string file in Directory.EnumerateFiles(targetFolder, "*.vb*", SearchOption.AllDirectories))
        {
           File.Delete(file);
        }
        foreach (string file in Directory.EnumerateFiles(targetFolder, "*vbproj*.*", SearchOption.AllDirectories))
        {
            File.Delete(file);
        }
    }
}
