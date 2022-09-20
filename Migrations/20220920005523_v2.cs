using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadiaMax",
                table: "Acomodacoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    FkEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false),
                    IdContato = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.FkEstabelecimento);
                    table.ForeignKey(
                        name: "FK_Contato_Estabelecimentos_FkEstabelecimento",
                        column: x => x.FkEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "FkEndereco",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropColumn(
                name: "EstadiaMax",
                table: "Acomodacoes");
        }
    }
}
