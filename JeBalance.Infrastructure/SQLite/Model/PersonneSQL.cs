using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Domain.Models;

namespace JeBalance.Infrastructure.SQLite.Model;

[Table("Personnes")]
public class PersonneSQL : Person
{
    [Column("Id")]
    public string Id { get; set; }
    [Column("Prenom")]
    public string FirstName { get; set; }
    [Column("Nom")]
    public string LastName { get; set; }
    [Column("Address")]
    public string Address { get; set; }
    [Column("IsBanned")]
    public bool IsBanned { get; set; }
    [Column("IsVIP")]
    public bool IsVIP { get; set; }
}
