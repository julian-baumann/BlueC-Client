using BlueCCli.Commands;
using BlueCLib.FirmwareClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        services.AddSingleton<IFirmwareClient, FirmwareClient>();
    }
}