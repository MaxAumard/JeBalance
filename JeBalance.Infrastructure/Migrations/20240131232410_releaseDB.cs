using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class releaseDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "PERSON",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    IsBanned = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVIP = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DENONCIATION",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    fk_Informant = table.Column<string>(type: "TEXT", nullable: false),
                    fk_Suspect = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Crime = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Response = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENONCIATION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DENONCIATION_PERSON_fk_Informant",
                        column: x => x.fk_Informant,
                        principalSchema: "app",
                        principalTable: "PERSON",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DENONCIATION_PERSON_fk_Suspect",
                        column: x => x.fk_Suspect,
                        principalSchema: "app",
                        principalTable: "PERSON",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATION_fk_Informant",
                schema: "app",
                table: "DENONCIATION",
                column: "fk_Informant");

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATION_fk_Suspect",
                schema: "app",
                table: "DENONCIATION",
                column: "fk_Suspect");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENONCIATION",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PERSON",
                schema: "app");
        }
    }
}
