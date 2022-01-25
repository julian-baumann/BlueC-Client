using BlueCLib.FirmwareClient;
using BlueCLib.Models;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace BlueCCli.Commands;

[Command ("deleteMessage")]
public class DeleteMessage : ICommand
{
    private readonly IFirmwareClient _firmwareClient;

    [CommandParameter(0, Name = "ChatroomId", Description = "Chatroom Id", IsRequired = true)]
    public string ChatroomId { get; set; }
    
    [CommandParameter(1, Name = "MessageId", Description = "Message Id", IsRequired = true)]
    public string MessageId { get; set; }

    public async ValueTask ExecuteAsync(IConsole console)
    {
        var chatroom = new Chatroom()
        {
            Id = ChatroomId,
            Name = "toDelete"
        };
        await _firmwareClient.DeleteMessageAsync(chatroom, MessageId);

        await console.Output.WriteAsync("Message deleted: " + ChatroomId + MessageId);
    }
}