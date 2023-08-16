using System.Net.WebSockets;

namespace R34;
public class ApiClient
{
    private readonly HttpClient _httpClient = new HttpClient();
    public async Task<Stream> GetContentAsync(string url)
    {
        var response = await ExecuteAsync(url);

        return await response.Content.ReadAsStreamAsync();
    }
    public async Task<HttpResponseMessage> ExecuteAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        return response;
    }
}
