using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.Query;

namespace JeBalance.UI.Data.Services;

public class ServiceBase<SourceType>
{
    private IHttpClientFactory _clientFactory;
    private CustomAuthenticationStateProvider _casp;

    private const string BaseURL = "https://localhost:7279/api/v1/";
    private string Controller;
    private string Endpoint => $"{BaseURL}{Controller}";

    public ServiceBase(
        IHttpClientFactory clientFactory,
        CustomAuthenticationStateProvider casp,
        string controller)
    {
        _clientFactory = clientFactory;
        _casp = casp;
        Controller = controller;
    }

    public async Task<HttpRequestMessage> MakePaginatedGetAllRequest(
        int limit,
        int offset,
        KeyValuePair<string, string>? filter)
    {
        var token = await _casp.GetJWT();

        var param = new Dictionary<string, string>()
        {
            { "limit", limit.ToString() },
            { "offset", offset.ToString() }
        };
        if (filter.HasValue)
        {
            param.Add(filter.Value.Key, filter.Value.Value);
        }

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            new Uri(QueryHelpers.AddQueryString(Endpoint, param)));

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);


        return request;
    }

    public async Task<HttpRequestMessage> MakeGetOneRequest(string id)
    {
        var token = await _casp.GetJWT();

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"{Endpoint}/{id}");

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeAddRequest(SourceType data)
    {
        var token = await _casp.GetJWT();

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{Endpoint}");

        var httpContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeUpdateRequest(int id, SourceType data)
    {
        var token = await _casp.GetJWT();

        var request = new HttpRequestMessage(
            HttpMethod.Put,
            $"{Endpoint}/{id}");

        var httpContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeDeleteRequest(string id)
    {
        var token = await _casp.GetJWT();

        var request = new HttpRequestMessage(
            HttpMethod.Delete,
            $"{Endpoint}/{id}");

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeActionRequest(string id, string action, object? payload = null)
    {
        var token = await _casp.GetJWT();

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{Endpoint}/{id}/{action}");

        if (payload != null)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");
            request.Content = httpContent;
        }

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakePaginatedRelatedDataRequest(
        int id,
        string relatedEndpoint,
        int limit, int offset,
        KeyValuePair<string, string>? filter)
    {
        var token = await _casp.GetJWT();

        var param = new Dictionary<string, string>()
        {
            { "limit", limit.ToString() },
            { "offset", offset.ToString() }
        };
        if (filter.HasValue)
        {
            param.Add(filter.Value.Key, filter.Value.Value);
        }

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            new Uri(QueryHelpers.AddQueryString(
                $"{Endpoint}/{id}/{relatedEndpoint}",
                param)));

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<SourceType[]> SendGetAllPaginatedRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default(SourceType[]);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<SourceType[]>(responseStream);
        return data;
    }

    public async Task<SourceType> SendGetOneRequest(HttpRequestMessage request)
    {
        try
        {
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            
            if (!response.IsSuccessStatusCode) return default(SourceType);
            
            using var responseStream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<SourceType>(responseStream);
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occurred: " + ex.Message);
            return default;
        }
    }

    public async Task<string> SendAddRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return string.Empty;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var id = await JsonSerializer.DeserializeAsync<string>(responseStream);
        return id;
    }

    public async Task<int> SendUpdateRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return 0;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var id = await JsonSerializer.DeserializeAsync<int>(responseStream);
        return id;
    }

    public async Task<bool> SendDeleteRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return false;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<bool>(responseStream);
        return result;
    }

    public async Task<bool> SendActionRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        return response.IsSuccessStatusCode;
    }

    public async Task<RelatedType[]> SendRelatedDataPaginatedRequest<RelatedType>(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default(RelatedType[]);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<RelatedType[]>(responseStream);
        return data;
    }
}