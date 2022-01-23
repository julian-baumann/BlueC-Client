using System;
using System.Net;
using System.Threading.Tasks;
using BlueCLib.Models;

namespace BlueCLib.FirmwareClient;

public interface IFirmwareClient
{
    public Task<Message> GetMessagesAsync(string chatroomId);
    public Task<Uri> SendMessageAsync(Chatroom chatroom, Message message);
    public Task<HttpStatusCode> DeleteMessageAsync(Chatroom chatroom, string id);
    public Task<Contact> GetContactsAsync();
    public Task<Uri> CreateContactAsync(Contact contact);
    public Task<Contact> UpdateContactsAsync(Contact contact);
    public Task<HttpStatusCode> DeleteContactAsync(string id);
}