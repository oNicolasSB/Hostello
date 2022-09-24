using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoResponsavel");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelFkUsuario",
                table: "Estabelecimentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_ResponsavelFkUsuario",
                table: "Estabelecimentos",
                column: "ResponsavelFkUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Estabelecimentos_Responsaveis_ResponsavelFkUsuario",
                table: "Estabelecimentos",
                column: "ResponsavelFkUsuario",
                principalTable: "Responsaveis",
                principalColumn: "FkUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estabelecimentos_Responsaveis_ResponsavelFkUsuario",
                table: "Estabelecimentos");

            migrationBuilder.DropIndex(
                name: "IX_Estabelecimentos_ResponsavelFkUsuario",
                table: "Estabelecimentos");

            migrationBuilder.DropColumn(
                name: "ResponsavelFkUsuario",
                table: "Estabelecimentos");

            migrationBuilder.CreateTable(
                name: "EstabelecimentoResponsavel",
                columns: table => new
                {
                    EstabelecimentosFkEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsaveisFkUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoResponsavel", x => new { x.EstabelecimentosFkEndereco, x.ResponsaveisFkUsuario });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoResponsavel_Estabelecimentos_EstabelecimentosFkEndereco",
                        column: x => x.EstabelecimentosFkEndereco,
                        principalTable: "Estabelecimentos",
                        principalColumn: "FkEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstabelecimentoResponsavel_Responsaveis_ResponsaveisFkUsuario",
                        column: x => x.ResponsaveisFkUsuario,
                        principalTable: "Responsaveis",
                        principalColumn: "FkUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentoResponsavel_ResponsaveisFkUsuario",
                table: "EstabelecimentoResponsavel",
                column: "ResponsaveisFkUsuario");
        }
    }
}
