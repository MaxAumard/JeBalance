using JeBalance.Domain.Contracts;
using JeBalance.Domain.Models;

namespace JeBalance.Domain.Repositories
{
    public interface IDenonciationRepository : Repository<Denonciation>
    {
        Task<string> SetResponse(string id, Response response);

        Task<int> CountDeclinedDenonciations(string informantId);

        public Task<(IEnumerable<Denonciation> Results, int Total)> FindUntreatedDenonciations(int limit, int offset);
    }
}