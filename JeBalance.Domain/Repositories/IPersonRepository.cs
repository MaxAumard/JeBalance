using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Domain.Repositories
{
    public interface IPersonRepository : Repository<Person>
    {
        Task<string> SetIsBanned(string id, bool isBanned);
        Task<string> SetIsVIP(string id, bool isVIP);
        Task<(IEnumerable<Person> Results, int Total)> GetAllVip(int limit, int offset, bool isVip);
        Task<(IEnumerable<Person> Results, int Total)> GetAllBanned(int limit, int offset, bool isBanned);
        Task<string> FindOrCreate(string firstName, string lastName, Address address);
        Task<string> GetPerson(Specification<Person> specification);
    }
}