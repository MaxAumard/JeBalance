using System.Collections.Generic;
using System.Threading.Tasks;
using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class InspectionOutputService : ServiceBase<DenonciationOutput>
{
    private const string BaseUrl = "https://localhost:7279/api/v1/";

    private const string Controller = "denonciations";

    public InspectionOutputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, BaseUrl, Controller)
    {
    }

    public async Task<(DenonciationOutput[] Items, int Total)> GetInspectionsAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(limit, offset, null);
        Console.WriteLine(request);
        return await SendGetAllPaginatedRequest(request);
    }
}