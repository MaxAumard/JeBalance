using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class NonVipOutputService: ServiceBase<PersonOutput>
{
    private const string Controller = "admin/vip";

    public NonVipOutputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
    {
    }
    
    public async Task<(PersonOutput[] Items, int Total)> GetNonVipAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(limit, offset, null);
        return await SendGetAllPaginatedRequest(request);
    }

}