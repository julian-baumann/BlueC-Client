using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlueCLib.Models;

namespace BlueCLib.FirmwareClient;

/// <summary>
/// Http-Client for BlueC-Firmware
/// </summary>
public class FirmwareClient : IFirmwareClient
{
    private readonly HttpClient Client = new HttpClient();
    private readonly string _baseAdress;
    public FirmwareClient(string baseAdress)
    {
        _baseAdress = baseAdress;
    }
    
    private async Task RunAsync()
    {
        Client.BaseAddress = new Uri("http://");
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<Message> GetMessagesAsync(string chatroomId)
    {
        Message message = null;
        HttpResponseMessage response = await Client.GetAsync(chatroomId);
        if (response.IsSuccessStatusCode)
        {
            message = await response.Content.ReadAsAsync<Message>();
        }
        return message;
    }

    public async Task<Uri> SendMessageAsync(Chatroom chatroom, Message message)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync($"api/chatrooms/{chatroom}/message", message);
        response.EnsureSuccessStatusCode();

        return response.Headers.Location;
    }
    
    public async Task<HttpStatusCode> DeleteMessageAsync (Chatroom chatroom, string id)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/{chatroom}/messages/{id}");
        return response.StatusCode;
    }


    public async Task<Contact> GetContactsAsync()
    {
        Contact contact = null;
        HttpResponseMessage response = await Client.GetAsync("api/contacts");
        if (response.IsSuccessStatusCode)
        {
            contact = await response.Content.ReadAsAsync<Contact>();
        }

        return contact;
    }
    
    public async Task<Uri> CreateContactAsync(Contact contact)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync("api/contacts", contact);
        response.EnsureSuccessStatusCode();

        return response.Headers.Location;
    }

    public async Task<Contact> UpdateContactsAsync(Contact contact)
    {
        HttpResponseMessage response = await Client.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);
        response.EnsureSuccessStatusCode();

        contact = await response.Content.ReadAsAsync<Contact>();
        return contact;
    }

    public async Task<HttpStatusCode> DeleteContactAsync(string id)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/contacts/{id}");
        return response.StatusCode;
    }
}