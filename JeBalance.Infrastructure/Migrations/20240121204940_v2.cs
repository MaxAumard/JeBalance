using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Denonciation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Informant = table.Column<string>(type: "TEXT", nullable: false),
                    Suspect = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Crime = table.Column<int>(type: "INTEGER", nullable: false),
                    Pays = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denonciation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denonciation");
        }
    }
}
