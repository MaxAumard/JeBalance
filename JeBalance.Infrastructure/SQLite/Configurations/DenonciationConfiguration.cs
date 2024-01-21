using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLite.Model;
using JeBalance.Infrastructure.SQLite;

namespace JeBlance.Infrastructure.SQLServer.Configurations;

internal class DenonciationConfiguration : IEntityTypeConfiguration<DenonciationSQL>
{
    public void Configure(EntityTypeBuilder<DenonciationSQL> builder)
    {
        builder
            .ToTable("Denonciation", DatabaseContext.DEFAULT_SCHEMA)
            .HasKey(denonciation => denonciation.Id);

        builder.Property(denonciation => denonciation.Informant)
            .IsRequired();

        builder.Property(denonciation => denonciation.Suspect)
            .IsRequired();

        builder.Property(denonciation => denonciation.Date)
            .IsRequired();

        builder.Property(denonciation => denonciation.Crime)
            .IsRequired();

        builder.Property(denonciation => denonciation.Pays)
            .IsRequired();

        builder.Property(denonciation => denonciation.Response)
            .IsRequired();
    }
}