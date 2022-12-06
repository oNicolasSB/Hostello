using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$e2OsnW4pAMryY/gls75wS.z1TIV98bJZDAXcILak90NGIqrJHNA2K");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$8QC49JUaIKqUmgANU5Wy7eZYK/tlbVygExdnCYEnLY6GnU5i6HiKG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$MS6IMjI9ULaXvLD1wJoDVepSo6LHEB0/2QsJgtzNt11Z/B4T9ZIRe");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$R/31fGV6ld14oxFp79kKZeqBfpS4Ad3iQxD28QjW2Nz81OOXHSIti");
        }
    }
}
