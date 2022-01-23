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
public class FirmwareClient
{
    private static readonly HttpClient Client = new HttpClient();
    private readonly string _baseAdress;
    public FirmwareClient(string baseAdress)
    {
        _baseAdress = baseAdress;
    }
    
    private static async Task RunAsync()
    {
        Client.BaseAddress = new Uri("http://");
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private static async Task<Message> GetMessagesAsync(string chatroomId)
    {
        Message message = null;
        HttpResponseMessage response = await Client.GetAsync(chatroomId);
        if (response.IsSuccessStatusCode)
        {
            message = await response.Content.ReadAsAsync<Message>();
        }
        return message;
    }

    private static async Task<Uri> SendMessageAsync(Message message)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync("api/messages", message);
        response.EnsureSuccessStatusCode();

        return response.Headers.Location;
    }
    
    private static async Task<HttpStatusCode> DeleteMessageAsync (string id)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/messages/{id}");
        return response.StatusCode;
    }


    private static async Task<Contact> GetContactsAsync()
    {
        Contact contact = null;
        HttpResponseMessage response = await Client.GetAsync("api/contacts");
        if (response.IsSuccessStatusCode)
        {
            contact = await response.Content.ReadAsAsync<Contact>();
        }

        return contact;
    }
    
    private static async Task<Uri> CreateContactAsync(Contact contact)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync("api/contacts", contact);
        response.EnsureSuccessStatusCode();

        return response.Headers.Location;
    }

    private static async Task<Contact> UpdateContactsAsync(Contact contact)
    {
        HttpResponseMessage response = await Client.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);
        response.EnsureSuccessStatusCode();

        contact = await response.Content.ReadAsAsync<Contact>();
        return contact;
    }

    private static async Task<HttpStatusCode> DeleteContactAsync(string id)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/contacts/{id}");
        return response.StatusCode;
    }
}