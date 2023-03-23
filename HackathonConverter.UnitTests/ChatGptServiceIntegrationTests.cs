namespace HackathonConverter.UnitTests;

public class ChatGptServiceIntegrationTests : IClassFixture<ConfigurationFixture>
{
    private readonly IChatGpt _chatGptClient;
    private readonly Mock<IOptions<ChatGPTSettings>> _optionsMock;

    public ChatGptServiceIntegrationTests(ConfigurationFixture configuration)
    {
        _chatGptClient = RestService.For<IChatGpt>(configuration.Configuration.GetValue<string>("ChatGPTSettings:BaseUrl"), new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                    { PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance })
            });
        _optionsMock = new Mock<IOptions<ChatGPTSettings>>();
        _optionsMock.Setup(i => i.Value).Returns(configuration.Configuration.GetSection("ChatGPTSettings").Get<ChatGPTSettings>());
    }

    [Theory]
    [MemberData(nameof(ValidSourceTestData))]
    public async Task ExecuteAsync_ReturnsConvertedCode_WhenValidSourceIsProvided(List<string> source, List<string> expectedOutput)
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var chatGptService = new ChatGptService(_optionsMock.Object, _chatGptClient);

        // Act
        var result = await chatGptService.ExecuteAsync(new List<string>(source), cancellationToken);

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    public static IEnumerable<object[]> ValidSourceTestData()
    {
        yield return new object[]
        {
            new List<string>
            {
                "Public Interface IFibonacciCalculator",
                "    Function Calculate(n As Integer) As Integer",
                "End Interface",
                "",
                "Public Class FibonacciCalculator",
                "    Implements IFibonacciCalculator",
                "",
                "    Public Function Calculate(ByVal n As Integer) As Integer Implements IFibonacciCalculator.Calculate",
                "        If n < 0 Then Throw New ArgumentException(\"n must be non-negative.\")",
                "",
                "        If n <= 1 Then",
                "            Return n",
                "        Else",
                "            Return Calculate(n - 1) + Calculate(n - 2)",
                "        End If",
                "    End Function",
                "End Class"
            }, 
            new List<string>
            {
                "",
                "",
                "public interface IFibonacciCalculator",
                "{",
                "    int Calculate(int n);",
                "}",
                "",
                "public class FibonacciCalculator : IFibonacciCalculator",
                "{",
                "    public int Calculate(int n)",
                "    {",
                "        if (n < 0) throw new ArgumentException(\"n must be non-negative.\");",
                "",
                "        if (n <= 1)",
                "        {",
                "            return n;",
                "        }",
                "        else",
                "        {",
                "            return Calculate(n - 1) + Calculate(n - 2);",
                "        }",
                "    }",
                "}"
            }
        };
    }
}