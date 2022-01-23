using BlueCLib.FirmwareClient;
using BlueCLib.Models;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace BlueCCli.Commands;

[Command("send")]
public class SendCommand : ICommand
{
    private readonly IFirmwareClient _firmwareClient;
    public SendCommand(IFirmwareClient firmwareClient)
    {
        _firmwareClient = firmwareClient;
    }
    
    [CommandOption("message")]
    public string Message { get; set; }
    
    public async ValueTask ExecuteAsync(IConsole console)
    {
        var message = new Message
        {
            Text = Message
        };

        await _firmwareClient.SendMessageAsync(message);
        
        await console.Output.WriteAsync("Hello World " + Message);
    }
}