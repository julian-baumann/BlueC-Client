using BlueCCli;
using CliFx;

var startup = new Startup();

var serviceProvider = startup.BuildServiceProvider();

await new CliApplicationBuilder()
    .SetTitle("BlueC CLI")
    .SetDescription("BlueC CLI description")
    .UseTypeActivator(serviceProvider.GetService)
    .AddCommandsFromThisAssembly()
    .Build()
    .RunAsync();