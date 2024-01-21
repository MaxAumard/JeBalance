using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class DenonciationRepositorySQL
{
    private readonly DatabaseContext _context;

    public DenonciationRepositorySQL(DatabaseContext databaseContext)
    {
        _context = databaseContext;
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

    public async Task<string> Update(string id, Denonciation denonciation)
    {
        
        var denonciationToUpdate = _context.Denonciations.First(denonciation => denonciation.Id == id);
        denonciationToUpdate.Informant = denonciation.Informant;
        denonciationToUpdate.Suspect = denonciation.Suspect;
        denonciationToUpdate.Date = denonciation.Date;
        denonciationToUpdate.Crime = denonciation.Crime;
        denonciationToUpdate.Pays = denonciation.Pays.Value;
        //denonciationToUpdate.Response = denonciation.Response;

        _context.Denonciations.Update(denonciationToUpdate);
        
        await _context.SaveChangesAsync();
        return id;
    }




}
