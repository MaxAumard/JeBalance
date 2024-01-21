using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Infrastructure.SQLite;

namespace JeBlance.Infrastructure.SQLServer.Configurations;

internal class PersonneConfiguration : IEntityTypeConfiguration<PersonneSQL>
{
    public void Configure(EntityTypeBuilder<PersonneSQL> builder)
    {
        builder
            .ToTable("PERSONNES", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(person => person.Id);

        builder.Property(person => person.FirstName)
            .IsRequired();

        builder.Property(person => person.LastName)
            .IsRequired();

        builder.Property(person => person.Address)
            .IsRequired();

        builder.Property(person => person.IsBanned)
            .IsRequired();

    }
}