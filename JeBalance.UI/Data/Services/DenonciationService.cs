using JeBalance.Domain.Models;
using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using JeBalance.UI.Data.Services;
using Microsoft.AspNetCore.Components.Authorization;


public class DenonciationService : ServiceBase<DenonciationOutput>
{
    private const string Controller = "denonciations";

    public DenonciationService(
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

    public async Task<string> AddDenonciationAsync(DenonciationOutput denonciation)
    {
        var request = await MakeAddRequest(denonciation);
        var id = await SendAddRequest(request);
        return id;
    }
}