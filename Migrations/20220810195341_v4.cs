using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstabelecimentoResponsavel",
                columns: table => new
                {
                    EstabelecimentosIdEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsaveisFkUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentoResponsavel", x => new { x.EstabelecimentosIdEstabelecimento, x.ResponsaveisFkUsuario });
                    table.ForeignKey(
                        name: "FK_EstabelecimentoResponsavel_Estabelecimentos_EstabelecimentosIdEstabelecimento",
                        column: x => x.EstabelecimentosIdEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "IdEstabelecimento",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstabelecimentoResponsavel");
        }
    }
}
