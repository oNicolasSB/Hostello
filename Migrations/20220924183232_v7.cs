using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Estabelecimentos_FkEstabelecimento",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "FkEstabelecimento",
                table: "Contatos",
                newName: "FkEstabelecimentoContato");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Estabelecimentos_FkEstabelecimentoContato",
                table: "Contatos",
                column: "FkEstabelecimentoContato",
                principalTable: "Estabelecimentos",
                principalColumn: "FkEndereco",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Estabelecimentos_FkEstabelecimentoContato",
                table: "Contatos");

            migrationBuilder.RenameColumn(
                name: "FkEstabelecimentoContato",
                table: "Contatos",
                newName: "FkEstabelecimento");

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Estabelecimentos_FkEstabelecimento",
                table: "Contatos",
                column: "FkEstabelecimento",
                principalTable: "Estabelecimentos",
                principalColumn: "FkEndereco",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
