using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace BlueCCli.Commands;

[Command("send")]
public class SendCommand : ICommand
{
    [CommandOption("message")]
    public string Message { get; set; }

    public ValueTask ExecuteAsync(IConsole console)
    {
        console.Output.Write("Hello World " + Message);

        return default;
    }
}