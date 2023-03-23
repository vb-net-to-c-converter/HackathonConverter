﻿namespace HackathonConverter.Services.Models;

public class ChatResponse
{
    public string Id { get; set; } = string.Empty;
    public string? Object { get; set; }
    public long? Created { get; set; }
    public string? Model { get; set; }
    public Usage? Usage { get; set; }
    public List<Choice> Choices { get; set; } = new();
}