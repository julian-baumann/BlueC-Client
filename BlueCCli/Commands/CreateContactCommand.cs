using BlueCLib.FirmwareClient;
using BlueCLib.Models;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace BlueCCli.Commands;

[Command ("createContact")]

public class CreateContact : ICommand
{
    private readonly IFirmwareClient _firmwareClient;
    
    //public CreateContactCommand(IFirmwareClient firmwareClient)
    //{
    //    _firmwareClient = firmwareClient;
    //}
    
    [CommandParameter(0, Name = "UserId", Description = "User ID", IsRequired = true)]
    public string UserId { get; set; }
    
    [CommandParameter(1, Name = "Name", Description = "Name", IsRequired = true)]
    public string NewName { get; set; }

    public async ValueTask ExecuteAsync(IConsole console)
    {
        var newContact = new Contact
        {
            Id = UserId,
            Name = NewName
        };

        await _firmwareClient.CreateContactAsync(newContact);

        await console.Output.WriteAsync("New contact: " + NewName);
    }
}