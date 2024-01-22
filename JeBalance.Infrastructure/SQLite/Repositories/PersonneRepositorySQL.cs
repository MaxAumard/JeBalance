using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class PersonneRepositorySQL
{
    private readonly DatabaseContext _context;

    public PersonneRepositorySQL(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public async Task<string> Create(Person Personne)
    {
        var PersonneToSave = Personne.ToSQL();
        await _context.Personnes.AddAsync(PersonneToSave);
        await _context.SaveChangesAsync();
        return PersonneToSave.Id;
    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            var person = await _context.Personnes.FirstOrDefaultAsync(person => person.Id == id);

            if (person == null)
                return true;

            _context.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<String> Update(String id, Person person)
    {
        

        var personToUpdate = _context.Personnes.First(person => person.Id == id);
        personToUpdate.FirstName = person.FirstName.Value;
        personToUpdate.LastName = person.LastName.Value;
        personToUpdate.Address = person.Address.ToSQL();
        personToUpdate.IsBanned = person.IsBanned;
        personToUpdate.IsVIP = person.IsVIP;

        _context.Personnes.Update(personToUpdate);
        
        await _context.SaveChangesAsync();
        return id;
    }

    //Query VIP
    public async Task<IEnumerable<Person>> GetAllVIP()
    {
        var persons = await _context.Personnes.Where(person => person.IsVIP == true).ToListAsync();
        return persons.Select(person => person.ToDomain());
    }

    public async Task<IEnumerable<Person>> GetAllNotVIP()
    {
        var persons = await _context.Personnes.Where(person => person.IsVIP == false).ToListAsync();
        return persons.Select(person => person.ToDomain());
    }

    //Query Banned
    public async Task<IEnumerable<Person>> GetAllBanned()
    {
        var persons = await _context.Personnes.Where(person => person.IsBanned == true).ToListAsync();
        return persons.Select(person => person.ToDomain());
    }

    public async Task<IEnumerable<Person>> GetAllNotBanned()
    {
        var persons = await _context.Personnes.Where(person => person.IsBanned == false).ToListAsync();
        return persons.Select(person => person.ToDomain());
    }


}
