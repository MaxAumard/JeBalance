using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace JeBalance.Infrastructure.SQLite.Model;

public class DenonciationSQL : Denonciation
{
    [Column("Id")] public new string Id { get; set; } = string.Empty;
    [Column("fk_Informant")] public new string InformantId { get; set; } = string.Empty;
    [Column("fk_Suspect")] public new string SuspectId { get; set; } = string.Empty;
    [Column("Date")] public new DateTimeOffset Date { get; set; }
    [Column("Crime")] public new Crime Crime { get; set; }
    [Column("Country")] public new string Country { get; set; } = string.Empty;
    [Column("Response")] public new string? Response { get; set; }

    [ForeignKey(nameof(InformantId))] public virtual PersonSQL? Informant { get; set; }
    [ForeignKey(nameof(SuspectId))] public virtual PersonSQL? Suspect { get; set; }
}