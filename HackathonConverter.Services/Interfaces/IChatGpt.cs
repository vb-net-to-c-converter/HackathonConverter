using HackathonConverter.Services.Models;
using Refit;

namespace HackathonConverter.Services.Interfaces;

[Headers("Content-Type: application/json")]
public interface IChatGpt
{
    [Post("/chat/completions")]
    Task<ChatResponse> ChatCompletion([Body] ChatRequest request, [Header("Authorization")] string token, CancellationToken cancellationToken);
}