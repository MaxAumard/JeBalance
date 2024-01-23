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
        throw new NotImplementedException();
    }

    public Task<Denonciation> GetOne(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasAny(Specification<Denonciation> specification)
    {
        throw new NotImplementedException();
    }

    public Task<string> SetResponse(string id, Response response)
    {
        throw new NotImplementedException();
    }

    public async Task<string> Update(string id, Denonciation denonciation)
    {
        
        var denonciationToUpdate = _context.Denonciations.First(denonciation => denonciation.Id == id);
        denonciationToUpdate.Informant = denonciation.Informant;
        denonciationToUpdate.Suspect = denonciation.Suspect;
        denonciationToUpdate.Date = denonciation.Date;
        denonciationToUpdate.Crime = denonciation.Crime;
        denonciationToUpdate.Country = denonciation.Country.Value;
        //denonciationToUpdate.Response = denonciation.Response;

        _context.Denonciations.Update(denonciationToUpdate);
        
        await _context.SaveChangesAsync();
        return id;
    }




}
