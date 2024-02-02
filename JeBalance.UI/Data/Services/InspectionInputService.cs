using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class InspectionInputService : ServiceBase<InspectionResponse>
{
    private const string BaseUrl = "https://localhost:7279/api/v1/";

    private const string Controller = "denonciations";

    public InspectionInputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, BaseUrl, Controller)
    {
    }

    public async Task<string> UpdateInspectionAsync(string id, InspectionResponse denonciationInput)
    {
        var request = await MakeUpdateRequest(id, denonciationInput);
        return await SendUpdateRequest(request);
    }
}