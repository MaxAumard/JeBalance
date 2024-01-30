using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;
using Microsoft.EntityFrameworkCore;
using JeBalance.Domain.Contracts;
using JeBalance.Domain.Repositories;
using JeBalance.Domain.ValueObjects;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Net;
using System.Linq;
using ParkNGo.Infrastructure.SQLServer.Repositories;

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
        return Task.FromResult(_context.Personnes
            .Apply(specification.ToSQLExpression<Person, PersonneSQL>())
            .Count());
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

    public async Task<(IEnumerable<Person> Results, int Total)> Find(int limit, int offset, Specification<Person> specification)
    {
        var results = _context.Personnes
            .Apply(specification.ToSQLExpression<Person, PersonneSQL>())
            .Skip(offset)
            .Take(limit)
            .AsEnumerable()
            .Select(driver => driver.ToDomain());

        return (results, _context.Personnes.Count());
    }

    public async Task<Person> GetOne(string id)
    {
        var person = await _context.Personnes.FirstOrDefaultAsync(person => person.Id == id);
        if (person.IsNullOrDefault())
        {
            return null;
        }
        return person.ToDomain();
    }

    public async Task<string> GetPerson(Specification<Person> specification)
    {
        var person = _context.Personnes
            .Apply(specification.ToSQLExpression<Person, PersonneSQL>())
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
        PersonneSQL personToUpdate = _context.Personnes.First(person => person.Id == id);   
        personToUpdate.IsBanned = isBanned;
         _context.Personnes.Update(personToUpdate);
        return id;
    }

    public async Task<string> SetIsVIP(string id, bool isVIP)
    {
        PersonneSQL personToUpdate = _context.Personnes.First(person => person.Id == id);
        personToUpdate.IsVIP = isVIP;
        _context.Personnes.Update(personToUpdate);
        return id;

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