namespace HackathonConverter.UnitTests;

public class ConfigurationFixture
{
    public IConfiguration Configuration { get; }

    public ConfigurationFixture()
    {
        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddJsonFile("appsettings.local.json", true)
            .Build();
    }
}