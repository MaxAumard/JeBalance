using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Repositories;
using ParkNGo.Infrastructure.SQLServer.Repositories;
using System.Runtime.CompilerServices;

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
        return Task.FromResult(_context.Persons
            .Apply(specification.ToSQLExpression<Person, PersonSQL>())
            .Count());
    }

    public async Task<string> Create(Person Personne)
    {
        var PersonneToSave = Personne.ToSQL();
        await _context.Persons.AddAsync(PersonneToSave);
        await _context.SaveChangesAsync();
        return PersonneToSave.Id;
    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            var person = await _context.Persons.FirstOrDefaultAsync(person => person.Id == id);

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

    public async Task<(IEnumerable<Person> Results, int Total)> Find(int limit, int offset, Specification<Person> specification)
    {
        var allPersons = _context.Persons
            .Apply(specification.ToSQLExpression<Person, PersonSQL>());
        var persons = allPersons
            .Skip(offset)
            .Take(limit)
            .AsEnumerable()
            .Select(denonciation => denonciation.ToDomain());
        var totalfound = await allPersons.CountAsync();
        return (persons, totalfound);
    }

    public async Task<Person> GetOne(string id)
    {
        var person = await _context.Persons.FirstOrDefaultAsync(person => person.Id == id);
        if (person.IsNullOrDefault())
        {
            return null;
        }
        return person.ToDomain();
    }

    public async Task<string> GetPerson(Specification<Person> specification)
    {
        var person = _context.Persons
            .Apply(specification.ToSQLExpression<Person, PersonSQL>())
            .Select(driver => driver.ToDomain())
            .FirstOrDefault();


        return person.IsNullOrDefault() ? "" : person.Id;
    }

    public Task<bool> HasAny(Specification<Person> specification)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SetIsBanned(string id, bool isBanned)
    {
        var personToUpdate = _context.Persons.First(person => person.Id == id);
        personToUpdate.IsBanned = isBanned;
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<string> SetIsVIP(string id, bool isVIP)
    {
        var personToUpdate = _context.Persons.First(person => person.Id == id);
        personToUpdate.IsVIP = isVIP;
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<String> Update(String id, Person person)
    {
        var personToUpdate = _context.Persons.First(person => person.Id == id);
        personToUpdate.FirstName = person.FirstName.Value;
        personToUpdate.LastName = person.LastName.Value;
        personToUpdate.Address = person.Address.ToSQL();
        personToUpdate.IsBanned = person.IsBanned;
        personToUpdate.IsVIP = person.IsVIP;

        _context.Persons.Update(personToUpdate);

        await _context.SaveChangesAsync();
        return id;
    }
}