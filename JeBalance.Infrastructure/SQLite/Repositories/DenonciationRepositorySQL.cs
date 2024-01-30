using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Repositories;
using ParkNGo.Infrastructure.SQLServer.Repositories;

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

    public async Task<(IEnumerable<Denonciation> Results, int Total)> Find(int limit, int offset, Specification<Denonciation> specification)
    {
        var results = _context.Denonciations
            .Apply(specification.ToSQLExpression<Denonciation, DenonciationSQL>())
            .Skip(offset)
            .Take(limit)
            .AsEnumerable()
            .Select(denonciation => denonciation.ToDomain());

        return (results, _context.Denonciations.Count());
    }

    public async Task<Denonciation> GetOne(string id)
    {
        DenonciationSQL? denonciation =  _context.Denonciations.FirstOrDefault(denonciation => denonciation.Id == id);
        if (denonciation.IsNullOrDefault())
        {
            return null;
        }
        return denonciation.ToDomain();
    }

    public async Task<bool> HasAny(Specification<Denonciation> specification)
    {
        return await _context.Denonciations
            .Apply(specification.ToSQLExpression<Denonciation, DenonciationSQL>())
            .AnyAsync();
    }

    public async Task<string> SetResponse(string id, Response response)
    {
        DenonciationSQL? denonciation =  _context.Denonciations.FirstOrDefault(denonciation => denonciation.Id == id);
        if (denonciation.IsNullOrDefault())
        {
            return null;
        }
        denonciation.Response = response.ToSQL();
        await _context.SaveChangesAsync();
        return id;
    }

    public Task<string> Update(string id, Denonciation T)
    {
        throw new NotImplementedException();
    }
}
