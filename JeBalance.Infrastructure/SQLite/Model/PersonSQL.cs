using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Models;

namespace JeBalance.Infrastructure.SQLite.Model;

public class PersonSQL : Person
{
    [Column("Id")]
    public new string Id { get; set; } = string.Empty;
    [Column("Prenom")]
    public new string FirstName { get; set; } = string.Empty;
    [Column("Nom")]
    public new string LastName { get; set; } = string.Empty;
    [Column("Address")]
    public new string Address { get; set; } = string.Empty;
    [Column("IsBanned")]
    public new bool IsBanned { get; set; }
    [Column("IsVIP")]
    public new bool IsVIP { get; set; }
}
