namespace HackathonConverter.Services.Models;

public class ChatRequest
{
    public string Model { get; set;  } = "gpt-3.5-turbo";
    public int Temperature { get; set; } = 0;
    public int MaxTokens { get; set; } = 2048;
    public int TopP { get; set; } = 1;
    public int FrequencyPenalty { get; set; } = 0;
    public int presence_penalty { get; set; } = 0;
    public List<Message> Messages { get; } = new();
}