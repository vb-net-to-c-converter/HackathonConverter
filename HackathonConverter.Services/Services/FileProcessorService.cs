using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonConverter.Services.Interfaces;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace HackathonConverter.Services.Services
{
    public static class FileProcessorService 
    {
        public static void ReadTextFromFile(string filePath)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(filePath))
                {

                    
                    // Read the stream as a string, and write the string to the console.
                    string text = sr.ReadToEnd();
                    
                    List<string> converterVbList = GetConverterVbList(text);
                    foreach (string line in converterVbList)
                    {
                        Console.WriteLine(line);
                    }
                    //Save to c# file
                    string fileName = "MainModule.cs";
                    string folderPath = "C:\\ILSource\\HackathonConverter\\Speciment";
                    SaveToFile(converterVbList, fileName, folderPath);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public static List<string> GetConverterVbList(string vbList)
        {
            List<string> converterVbList = new List<string>();

            string[] lines = vbList.Split("\n");

            foreach (string line in lines)
            {
                if (! string.IsNullOrWhiteSpace(line))
                {
                    converterVbList.Add(line);
                }
                
            }
            return converterVbList;
        }

        public static void ConverterVBtoC(string lineToConverter)
        {
            Console.WriteLine(lineToConverter);
        }

        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive) 
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        public static void SaveToFile(List<string> fileDataList, string fileName,string folderPath)
        {
            // Write the string array to a new file 
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderPath, fileName)))
            {
                foreach (string line in fileDataList)
                    outputFile.WriteLine(line);
            }
        }

    }
}
