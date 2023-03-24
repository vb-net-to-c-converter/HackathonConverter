using HackathonConverter.Services.Interfaces;
using HackathonConverter.Services.Models;
using HackathonConverter.Services.Utils;
using Microsoft.Extensions.Options;

namespace HackathonConverter.Services.Services;

public class ChatGptService : IChatGptService
{
    private readonly ChatGPTSettings _settings;
    private readonly IChatGpt _chatGptClient;

    public ChatGptService(IOptions<ChatGPTSettings> settings, IChatGpt chatGptClient)
    {
        _settings = settings.Value;
        _chatGptClient = chatGptClient;
    }

    public async Task<List<string>> ExecuteAsync(List<string> source, CancellationToken cancellationToken = default)
    {
        var request = new ChatRequest();
        request.Messages.Add(new Message{Content = $"Convert the following VB.NET code to C#, in output should be only code:{source.ListToString()}"});
        var response = await _chatGptClient.ChatCompletion(request, $"Bearer {_settings.Token}", cancellationToken);
        if (response.Choices.Count == 0 || string.IsNullOrEmpty(response.Choices[0].Message?.Content)) return new List<string>();
        return response.Choices[0].Message?.Content.StringToList() ?? new List<string>();
    }
}