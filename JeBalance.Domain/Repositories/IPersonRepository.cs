using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Repositories
{
    public interface IPersonRepository : Repository<Person>
    {
        Task<string> SetIsBanned(string id, bool isBanned);
        Task<string> SetIsVIP(string id, bool isVIP);
    }
}