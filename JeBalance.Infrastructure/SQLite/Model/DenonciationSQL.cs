using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace JeBalance.Infrastructure.SQLite.Model;

[Table("Denonciation")]
public class DenonciationSQL : Denonciation
{
    [Column("Id")]
    public new string Id { get; set; } = string.Empty;
    [Column("Informant")]
    public new string Informant { get; set; } = string.Empty;
    [Column("Suspect")]
    public new string Suspect { get; set; } = string.Empty;
    [Column("Date")]
    public new DateTimeOffset Date { get; set; }
    [Column("Crime")]
    public new Crime Crime { get; set; }
    [Column("Country")]
    public new string Country { get; set; } = string.Empty;
    [AllowNull]
    [Column("Response")]
    public new string? Response { get; set; }

}
