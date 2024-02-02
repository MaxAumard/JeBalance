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

public class DenonciationRepositoryTests : RepositoryTest
{
    private readonly DenonciationRepositorySQL _repository;

    public DenonciationRepositoryTests() : base()
    {
        _repository = new DenonciationRepositorySQL(Context);
    }

    [Fact]
    public async Task ShouldCreate()
    {
        var denonciation = new Denonciation("12", "12", "12", DateTimeOffset.Now, Crime.DissimulationDeRevenus, "122");
        var result = await _repository.Create(denonciation);
        Assert.Equal(denonciation.Id, result);
    }

    [Fact]
    public async Task ShouldDelete()
    {
        var denonciation = new Denonciation("12", "12", "12", DateTimeOffset.Now, Crime.DissimulationDeRevenus, "122");
        await _repository.Create(denonciation);
        var result = await _repository.Delete(denonciation.Id);
        Assert.True(result);
    }

    [Fact]
    public async Task ShouldUpdate()
    {
        var denonciation = new Denonciation("12", "12", "12", DateTimeOffset.Now, Crime.DissimulationDeRevenus, "122");
        await _repository.Create(denonciation);
        var result = await _repository.Update(denonciation.Id, denonciation);
        Assert.Equal(denonciation.Id, result);
    }
}