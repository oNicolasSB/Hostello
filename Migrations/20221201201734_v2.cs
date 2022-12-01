using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_FkEndereco",
                table: "Usuarios");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_FkEndereco",
                table: "Usuarios",
                column: "FkEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Enderecos_FkEndereco",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$i4qMnE0jI21AHsW1ycWHtuKP5DwUCpFVdFHEzounB6saleAFYqzN6");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$A79eRYBpXxXrjrdg9ZdLN.XNAtP45twlbT6MHhwp0sF1ZVa0dA4yy");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Enderecos_FkEndereco",
                table: "Usuarios",
                column: "FkEndereco",
                principalTable: "Enderecos",
                principalColumn: "IdEndereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
