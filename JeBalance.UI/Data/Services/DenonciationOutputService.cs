using JeBalance.Domain.Models;
using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using JeBalance.UI.Data.Services;
using Microsoft.AspNetCore.Components.Authorization;


public class DenonciationOutputService : ServiceBase<DenonciationOutput>
{
    private const string Controller = "denonciations";

    public DenonciationOutputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, Controller)
    {
    }

    public async Task<DenonciationOutput> GetDenonciationAsync(string id)
    {
        var request = await MakeGetOneRequest(id);
        var denonciation = await SendGetOneRequest(request);
        return denonciation;
    }
    
}