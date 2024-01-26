using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.SQLite.Repositories;

public class PersonRepositorySQL : IPersonRepository
{
    private readonly DatabaseContext _context;

    public PersonRepositorySQL(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public Task<int> Count(Specification<Person> specification)
    {
        throw new NotImplementedException();
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

    public Task<(IEnumerable<Person> Results, int Total)> Find(int limit, int offset,
        Specification<Person> specification)
    {
        var persons = _context.Personnes.Skip(offset).Take(limit).ToList();
        return Task.FromResult((persons.Select(person => person.ToDomain()).Where(specification.IsSatisfiedBy), persons.Count));
    }

    public Task<string> FindOrCreate(string firstName, string lastName, Address address)
    {
        throw new NotImplementedException();
    }


    public Task<Person> GetOne(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasAny(Specification<Person> specification)
    {
        throw new NotImplementedException();
    }

    public Task<string> SetIsBanned(string id, bool isBanned)
    {
        var personToUpdate = _context.Personnes.First(person => person.Id == id);
        personToUpdate.IsBanned = isBanned;
        _context.Personnes.Update(personToUpdate);
        _context.SaveChanges();
        return Task.FromResult(id);
    }

    public Task<string> SetIsVIP(string id, bool isVIP)
    {
        var personToUpdate = _context.Personnes.First(person => person.Id == id);
        personToUpdate.IsVIP = isVIP;
        _context.Personnes.Update(personToUpdate);
        _context.SaveChanges();
        return Task.FromResult(id);
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
}