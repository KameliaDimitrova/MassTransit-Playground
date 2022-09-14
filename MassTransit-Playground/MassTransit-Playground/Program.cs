namespace MassTransit_Playground.Api;

public sealed class Program
{ 
    private Program()
    {

    }

    public static async Task Main(string[] args)
    {
        var builder = Startup.ConfigureWebApplicationBuilder(args);

        var app = Startup.ConfigureWebApplication(builder);

        await app.RunAsync().ConfigureAwait(false);
    }
}