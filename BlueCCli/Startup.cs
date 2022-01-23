using BlueCCli.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BlueCCli;

public class Startup
{

    public ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        return services.BuildServiceProvider();
    }
    
    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<SendCommand>();
    }
}