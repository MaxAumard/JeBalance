using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Repositories
{
    public interface IDenonciationRepository : Repository<Denonciation>
    {
        Task<string> SetResponse(string id, Response response);
    }
}
