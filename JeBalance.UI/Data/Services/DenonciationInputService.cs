using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class DenonciationInputService : ServiceBase<DenonciationInput>
{
    private const string BaseUrl = "https://localhost:7279/api/v1/";

    private const string Controller = "denonciations";

    public DenonciationInputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, BaseUrl, Controller)
    {
    }


    public async Task<string> AddDenonciationAsync(DenonciationInput denonciation)
    {
        try
        {
            var request = await MakeAddRequest(denonciation);
            var id = await SendAddRequest(request);
            return id;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}