using System.Text;

namespace HackathonConverter.Services.Utils;

public static class StringExtensions
{
    public static string ListToString(this List<string> source, string delimiter = "\n")
    {
        var builder = new StringBuilder();
        builder.AppendJoin(delimiter, source);
        return builder.ToString();
    }

    public static List<string> StringToList(this string source, string delimiter = "\n")
    {
        return source.Split(delimiter).ToList();
    }
}