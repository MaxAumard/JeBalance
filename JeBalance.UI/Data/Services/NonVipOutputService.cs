using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class NonVipOutputService : ServiceBase<PersonOutput>
{
    private const string BaseUrl = "https://localhost:7232/api/v1/";
    private const string Controller = "admin/non-vip";

    public NonVipOutputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, BaseUrl, Controller)
    {
    }

    public async Task<(PersonOutput[] Items, int Total)> GetNonVipAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(limit, offset, null);
        return await SendGetAllPaginatedRequest(request);
    }
}