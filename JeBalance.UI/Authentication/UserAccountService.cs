using System.Text;
using System.Text.Json;

namespace JeBalance.UI.Authentication;

public class UserAccountService
{
    private IHttpClientFactory _clientFactory;

    public UserAccountService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<UserSession?> LoginAsync(string username, string password)
    {
        var request = MakeRequest(username, password);
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode) return null;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var session = await JsonSerializer.DeserializeAsync<UserSession>(responseStream);
        return session;
    }

    private HttpRequestMessage MakeRequest(string username, string password)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://localhost:7231/api/v1/auth/login");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        var httpContent = new StringContent(
            JsonSerializer.Serialize(new { username, password }),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        return request;
    }
}