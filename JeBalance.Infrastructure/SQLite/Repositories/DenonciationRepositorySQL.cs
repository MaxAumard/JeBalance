using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Repositories;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class DenonciationRepositorySQL : IDenonciationRepository
{
    private readonly DatabaseContext _context;

    public DenonciationRepositorySQL(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public Task<int> Count(Specification<Denonciation> specification)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Create(Denonciation denonciation)
    {
        var DenonciationToSave = denonciation.ToSQL();
        await _context.Denonciations.AddAsync(DenonciationToSave);
        await _context.SaveChangesAsync();
        return DenonciationToSave.Id;
    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            var denonciation = await _context.Denonciations.FirstOrDefaultAsync(denonciation => denonciation.Id == id);

            if (denonciation == null)
                return true;

            _context.Remove(denonciation);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset, Specification<Denonciation> specification)
    {
        IEnumerable<Denonciation> result = _context.Denonciations.Where(specification.IsSatisfiedBy);
        int total = result.Count();
        result = result.Skip(offset).Take(limit);
        return Task.FromResult((result, total));
    }

    public Task<Denonciation> GetOne(string id)
    {
        var denonciation = _context.Denonciations.FirstOrDefault(denonciation => denonciation.Id == id);
        return denonciation == null ?  throw new KeyNotFoundException() : Task.FromResult(denonciation.ToDomain());

    }

    public Task<bool> HasAny(Specification<Denonciation> specification)
    {
        throw new NotImplementedException();
    }

    public Task<string> SetResponse(string id, Response response)
    {
        Denonciation? denonciationToUpdate = _context.Denonciations.FirstOrDefault(d => d.Id == id);

        if (denonciationToUpdate != null)
        {
            denonciationToUpdate.Response = response;

            return Task.FromResult(id);
        }
        else
        {
            return Task.FromResult("Not Found"); ;
        }
    }

    public Task<string> Update(string id, Denonciation T)
    {
        throw new NotImplementedException();
    }
}
