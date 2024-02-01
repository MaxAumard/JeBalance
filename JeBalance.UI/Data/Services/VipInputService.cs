using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class VipInputService : ServiceBase<PersonOutput>
{
    private const string Controller = "admin/vip";

    public VipInputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
    {
    }
    
    public async Task<string> AddVipAsync(PersonOutput pers)
    {
        var request = await MakeAddRequest(pers);
        var id = await SendAddRequest(request);
        return id;
    }
    
    
    
    
    
    
}