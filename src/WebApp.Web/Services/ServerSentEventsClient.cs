using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace WebApp.Web.Services
{
    public class ServerSentEventsClient
    {
        private readonly Uri _endpoint;
        private readonly HttpClient _httpClient;

        public ServerSentEventsClient(Uri endpoint, HttpClient httpClient)
        {
            _endpoint = endpoint;
            _httpClient = httpClient;
        }

        public async IAsyncEnumerable<SseEvent> GetEventsAsync(HttpContent content)
        {
            using var response = await _httpClient.PostAsync(_endpoint.ToString(), content);
            response.EnsureSuccessStatusCode();
            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);
            string? line;
            string? data = null;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line.StartsWith("data:"))
                {
                    data = line.Substring(5).Trim();
                    yield return new SseEvent { Data = data };
                }
            }
        }
    }

    public class SseEvent
    {
        public string? Data { get; set; }
    }
}
