using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Estabelecimentos_FkEstabelecimento",
                table: "Contato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contato",
                table: "Contato");

            migrationBuilder.RenameTable(
                name: "Contato",
                newName: "Contatos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos",
                column: "FkEstabelecimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Estabelecimentos_FkEstabelecimento",
                table: "Contatos",
                column: "FkEstabelecimento",
                principalTable: "Estabelecimentos",
                principalColumn: "FkEndereco",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Estabelecimentos_FkEstabelecimento",
                table: "Contatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contatos",
                table: "Contatos");

            migrationBuilder.RenameTable(
                name: "Contatos",
                newName: "Contato");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contato",
                table: "Contato",
                column: "FkEstabelecimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Estabelecimentos_FkEstabelecimento",
                table: "Contato",
                column: "FkEstabelecimento",
                principalTable: "Estabelecimentos",
                principalColumn: "FkEndereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
