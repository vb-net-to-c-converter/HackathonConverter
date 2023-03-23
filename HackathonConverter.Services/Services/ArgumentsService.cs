using HackathonConverter.Services.Interfaces;

namespace HackathonConverter.Services.Services;

public class ArgumentsService : IArguments
{
    public string Path { get; }

    public ArgumentsService(string[] args)
    {
        var argument = args.FirstOrDefault(i => i.ToLower().StartsWith("--path="));
        Path = argument != null ? GetValue(argument) : throw new ArgumentNullException("path");
    }

    private string GetValue(string argument)
    {
        var split = argument.Split('=', StringSplitOptions.TrimEntries);
        if (split.Length != 2) throw new Exception($"Incorrect argument provided - {argument}");
        var result = System.IO.Path.GetFullPath(split[1]);
        
        return result;
    }
}