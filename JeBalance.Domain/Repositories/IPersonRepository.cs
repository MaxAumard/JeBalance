using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Repositories
{
    public interface IPersonRepository : Repository<Person>
    {
        Task<int> SetIsBanned(string id, bool isBanned);
        Task<int> SetIsVIP(string id, bool isVIP);
    }
}