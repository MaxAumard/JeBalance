using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class VipOutputService: ServiceBase<DenonciationOutput>
{
    private const string Controller = "admin/vip";

    public VipOutputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
    {
    }
    
    public async Task<(DenonciationOutput[] Items, int Total)> GetVipAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(limit, offset, null);
        return await SendGetAllPaginatedRequest(request);
    }

}