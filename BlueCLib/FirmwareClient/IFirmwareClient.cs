using System;
using System.Threading.Tasks;
using BlueCLib.Models;

namespace BlueCLib.FirmwareClient;

public interface IFirmwareClient
{
    public Task<Uri> SendMessageAsync(Message message);
}