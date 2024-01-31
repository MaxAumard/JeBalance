using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class rename_PersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PERSONNES",
                schema: "app",
                table: "PERSONNES");

            migrationBuilder.RenameTable(
                name: "PERSONNES",
                schema: "app",
                newName: "PERSON",
                newSchema: "app");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PERSON",
                schema: "app",
                table: "PERSON",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PERSON",
                schema: "app",
                table: "PERSON");

            migrationBuilder.RenameTable(
                name: "PERSON",
                schema: "app",
                newName: "PERSONNES",
                newSchema: "app");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PERSONNES",
                schema: "app",
                table: "PERSONNES",
                column: "Id");
        }
    }
}
