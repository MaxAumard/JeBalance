using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class DenonciationInputService : ServiceBase<DenonciationInput>
{
    private const string Controller = "denonciations";

    public DenonciationInputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
    {
    }
    
    
    public async Task<string> AddDenonciationAsync(DenonciationInput denonciation)
    {
        var request = await MakeAddRequest(denonciation);
        var id = await SendAddRequest(request);
        return id;
    }
}