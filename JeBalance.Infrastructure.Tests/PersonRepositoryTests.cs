using JeBalance.Domain.Models;
using JeBalance.Domain.Queries;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Repositories;
using JeBalance.Infrastructure.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public class PersonRepositoryTests : RepositoryTest
{
    private readonly PersonRepositorySQL _repository;
    public PersonRepositoryTests() : base()
    {
        _repository = new PersonRepositorySQL(Context);
    }

    [Fact]
    public async Task ShouldCreate()
    {
        var person = new Person("12", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), false, true);
        var result = await _repository.Create(person);
        Assert.Equal(Context.Personnes.Last().Id, result);
    }

    [Fact]
    public async Task ShouldDelete()
    {
        var person = new Person("12", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), false, true);
        await _repository.Create(person);
        var result = await _repository.Delete(person.Id);
        Assert.True(result);
    }

    [Fact]
    public async Task ShouldUpdate()
    {
        var person = new Person("12", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), false, true);
        await _repository.Create(person);
        var person2 = new Person("12", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), false, true);
        var result = await _repository.Update(person.Id, person2);
        Assert.Equal(person.Id, result);
    }

    [Fact]
    public async Task ShouldGetAllVIP()
    {
        var person = new Person("12", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), false, true);
        await _repository.Create(person);
        var person2 = new Person("13", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), false, false);
        await _repository.Create(person2);
        var result = await _repository.GetAllVIP();
        Person firstVIPPerson = result.ElementAtOrDefault(0);
    }

    [Fact]
    public async Task ShouldGetAllBanned()
    {
        var person = new Person("12", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), true, true);
        await _repository.Create(person);
        var person2 = new Person("13", new Name("albert"), new Name("keke"), new Address(12, new Name("tata"), new PostalCode(11111), new Name("oui")), true, false);
        await _repository.Create(person2);
        IEnumerable<Person> result = await _repository.GetAllBanned();
        Person firstBannedPerson = result.ElementAtOrDefault(1);
    }

}
