using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Infrastructure.SQLite;

namespace JeBlance.Infrastructure.SQLServer.Configurations;

internal class PersonConfiguration : IEntityTypeConfiguration<PersonSQL>
{
    public void Configure(EntityTypeBuilder<PersonSQL> builder)
    {
        builder
            .ToTable("PERSON", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(person => person.Id);

        builder.Property(person => person.FirstName)
            .IsRequired();

        builder.Property(person => person.LastName)
            .IsRequired();

        builder.Property(person => person.Address)
            .IsRequired();

        builder.Property(person => person.IsBanned)
            .IsRequired();

        builder.Property(person => person.IsVIP)
            .IsRequired();
    }
}