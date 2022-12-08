using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aprovado",
                table: "Acomodacoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$LtW2I.5uNR4d5wXhknZeReTZfRdrlW.a0yrq1lURea6EfbPWY0HbS");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 3,
                column: "Senha",
                value: "$2a$10$MO40YIRRTEPpWbR9F9qz8.Z7//TzpZy1e3SVh3qqUkfapADtda9wS");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$N0TMi9NUTs8WVw6FNCuo3.yhNCNl4ASWz8vlr48uQIuH.OExdjUa2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovado",
                table: "Acomodacoes");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$lraGUtJkgRPYULZyZ6woXuj3E84PIE6gv2nXdBf7IieNUkHMpsPKe");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 3,
                column: "Senha",
                value: "$2a$10$nurhPWOXEHWWYr0ofVSNpOc/v3r4.0oA79WvL2yagd.IQZ.WTiykq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$4W3X.k9Te4rigXlgDbXEs.cOzSs8NnwzbcvCj1nFTBVuJ3erJRxNK");
        }
    }
}
