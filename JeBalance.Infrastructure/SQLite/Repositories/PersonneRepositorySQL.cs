using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Domain.Models;

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
}
