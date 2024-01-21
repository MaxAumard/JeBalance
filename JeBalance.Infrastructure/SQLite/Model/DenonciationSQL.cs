using JeBalance.Domain.Models;
using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeBalance.Infrastructure.SQLite.Model;

[Table("Denonciation")]
public class DenonciationSQL : Denonciation
{
    [Column("Id")]
    public string Id { get; set; }
    [Column("Informant")]
    public string Informant { get; set; }
    [Column("Suspect")]
    public string Suspect { get; set; }
    [Column("Date")]
    public DateTimeOffset Date { get; set; }
    [Column("Crime")]
    public Crime Crime { get; set; }
    [Column("Pays")]
    public string Pays { get; set; }
    //[Column("Response")]
    //public Response? Response { get; set; }
}
