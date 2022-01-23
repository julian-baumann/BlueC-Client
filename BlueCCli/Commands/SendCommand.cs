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

    [CommandOption("chatroom",'c', IsRequired = true)] 
    public string ChatroomId { get; set; }
    
    // [CommandOption("user",'u', IsRequired = false)] 
    // public string UserId { get; set; }
    //
    // [CommandOption("name",'n', IsRequired = false)] 
    // public string Name { get; set; }

    [CommandParameter(1, Name = "Message", Description = "Your Message", IsRequired = true)]  
    public string Message { get; set; }
    
    public async ValueTask ExecuteAsync(IConsole console)
    {
        var chatroomId = new Chatroom
        {
            Id = ChatroomId
        };
        
        var message = new Message
        {
            Text = Message
        };

        await _firmwareClient.SendMessageAsync(chatroomId, message);
        
        await console.Output.WriteAsync("Hello World " + Message);
    }
}