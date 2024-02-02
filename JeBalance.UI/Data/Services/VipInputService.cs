using JeBalance.Domain.Commands.Persons;
using JeBalance.Inspection.Ressources;
using JeBalance.UI.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services;

public class VipInputService : ServiceBase<PersonOutput>
{
    private const string BaseUrl = "https://localhost:7232/api/v1/";
    private const string Controller = "admin/vip";

    public VipInputService(
        IHttpClientFactory clientFactory,
        AuthenticationStateProvider authStateProvider)
        : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider, BaseUrl, Controller)
    {
    }

    public async Task<string> AddVipAsync(PersonOutput pers, bool isVip = true)
    {
        var request =
            await MakeUpdateRequest(pers.Id, pers, new KeyValuePair<string, string>("isVIP", isVip.ToString()));
        var id = await SendAddRequest(request);
        return id;
    }
}