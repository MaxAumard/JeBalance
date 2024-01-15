using JeBalance.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeBalance.Infrastructure.SQLite.Model;

public class AddressSQL : Address
{
    [Column("Number")]
    public int Number { get; set; }
    [Column("StreetName")]
    public Name StreetName { get; set; }
    [Column("PostalCode")]
    public PostalCode PostalCode { get; set; }
    [Column("City")]
    public Name City { get; set; }
}

