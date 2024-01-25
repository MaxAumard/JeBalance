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
        return Task.FromResult(_context.Personnes.Count());
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

    public Task<(IEnumerable<Person> Results, int Total)> Find(int limit, int offset, Specification<Person> specification)
    {
        IEnumerable<Person> result = _context.Personnes.Where(specification.IsSatisfiedBy);
        int total = result.Count();
        result = result.Skip(offset).Take(limit);
        return Task.FromResult((result, total));
    }

    public Task<string> FindOrCreate(string firstName, string lastName, Address address)
    {
        Person? existingPerson = _context.Personnes.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName && p.Address.Equals(address));

        if (existingPerson != null)
        {
            return Task.FromResult(existingPerson.Id);
        }
        else
        {
            Person newPerson = new Person(Guid.NewGuid().ToString(), firstName, lastName, address);
            return Create(newPerson);
        }

    }

    public Task<(IEnumerable<Person> Results, int Total)> GetAllBanned(int limit, int offset, bool isBanned)
    {
        IEnumerable<Person> result = _context.Personnes.Where(p => p.IsBanned == isBanned);
        int total = result.Count();
        result = result.Skip(offset).Take(limit);
        return Task.FromResult((result, total));
    }

    public Task<(IEnumerable<Person> Results, int Total)> GetAllVip(int limit, int offset, bool isVip)
    {
        IEnumerable<Person> result = _context.Personnes.Where(p => p.IsVIP == isVip);
        int total = result.Count();
        result = result.Skip(offset).Take(limit);
        return Task.FromResult((result, total));
    }

    public Task<Person> GetOne(string id)
    {
        Person? existingPerson = _context.Personnes.FirstOrDefault(p => p.Id == id);
        return existingPerson == null ? throw new KeyNotFoundException() : Task.FromResult(existingPerson);

    }

    public Task<string> GetPerson(Specification<Person> specification)
    {
        Person? person = _context.Personnes.FirstOrDefault(specification.IsSatisfiedBy);
        return person == null ? Task.FromResult("") : Task.FromResult(person.Id);
    }

    public Task<bool> HasAny(Specification<Person> specification)
    {
        throw new NotImplementedException();
    }

    public Task<string> SetIsBanned(string id, bool isBanned)
    {
        PersonneSQL personToUpdate = _context.Personnes.First(person => person.Id == id);   
        personToUpdate.IsBanned = isBanned;
        _context.Personnes.Update(personToUpdate);
        return Task.FromResult(id);
    }

    public Task<string> SetIsVIP(string id, bool isVIP)
    {
        PersonneSQL personToUpdate = _context.Personnes.First(person => person.Id == id);
        personToUpdate.IsVIP = isVIP;
        _context.Personnes.Update(personToUpdate);
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
