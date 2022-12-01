using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hostello.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Logradouro = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    Complemento = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cep = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Pais = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "TiposAcomodacoes",
                columns: table => new
                {
                    IdTipoAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTipoAcomodacao = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAcomodacoes", x => x.IdTipoAcomodacao);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    IdEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    TelefoneFixo = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    MediaAvaliacao = table.Column<double>(type: "REAL", nullable: true),
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.IdEstabelecimento);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Enderecos_FkEndereco",
                        column: x => x.FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Senha = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sexo = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Cliente_FkEndereco = table.Column<int>(type: "INTEGER", nullable: true),
                    CNPJ = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    NomeFantasia = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Celular = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    RazaoSocial = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    MediaAvaliacao = table.Column<double>(type: "REAL", nullable: true),
                    FkEndereco = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_Cliente_FkEndereco",
                        column: x => x.Cliente_FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco");
                    table.ForeignKey(
                        name: "FK_Usuarios_Enderecos_FkEndereco",
                        column: x => x.FkEndereco,
                        principalTable: "Enderecos",
                        principalColumn: "IdEndereco");
                });

            migrationBuilder.CreateTable(
                name: "Acomodacoes",
                columns: table => new
                {
                    IdAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaAvaliacaoQuarto = table.Column<double>(type: "REAL", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoasMax = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMin = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadiaMax = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDiaria = table.Column<double>(type: "REAL", nullable: false),
                    FkAdministrador = table.Column<int>(type: "INTEGER", nullable: true),
                    FkTipoAcomodacao = table.Column<int>(type: "INTEGER", nullable: false),
                    FkEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelIdUsuario = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acomodacoes", x => x.IdAcomodacao);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Estabelecimentos_FkEstabelecimento",
                        column: x => x.FkEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "IdEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_TiposAcomodacoes_FkTipoAcomodacao",
                        column: x => x.FkTipoAcomodacao,
                        principalTable: "TiposAcomodacoes",
                        principalColumn: "IdTipoAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Usuarios_FkAdministrador",
                        column: x => x.FkAdministrador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Acomodacoes_Usuarios_ResponsavelIdUsuario",
                        column: x => x.ResponsavelIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    IdContato = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    FkEstabelecimento = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelIdUsuario = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.IdContato);
                    table.ForeignKey(
                        name: "FK_Contatos_Estabelecimentos_FkEstabelecimento",
                        column: x => x.FkEstabelecimento,
                        principalTable: "Estabelecimentos",
                        principalColumn: "IdEstabelecimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contatos_Usuarios_ResponsavelIdUsuario",
                        column: x => x.ResponsavelIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataAvaliacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NotaAvaliacao = table.Column<double>(type: "REAL", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Aprovado = table.Column<bool>(type: "INTEGER", nullable: true),
                    FkAdministrador = table.Column<int>(type: "INTEGER", nullable: true),
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    FkAcomodacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Acomodacoes_FkAcomodacao",
                        column: x => x.FkAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "IdAcomodacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_FkAdministrador",
                        column: x => x.FkAdministrador,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadiaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadiaSaida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorReserva = table.Column<double>(type: "REAL", nullable: false),
                    FkCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    AcomodacaoIdAcomodacao = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Acomodacoes_AcomodacaoIdAcomodacao",
                        column: x => x.AcomodacaoIdAcomodacao,
                        principalTable: "Acomodacoes",
                        principalColumn: "IdAcomodacao");
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 1, "Suíte" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 2, "Internet" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 3, "Estacionamento" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 4, "ArCondicionado" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 5, "Elevador" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 6, "TV" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 7, "Frigobar" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nome" },
                values: new object[] { 8, "BeiraMar" });

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkAdministrador",
                table: "Acomodacoes",
                column: "FkAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkEstabelecimento",
                table: "Acomodacoes",
                column: "FkEstabelecimento");

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_FkTipoAcomodacao",
                table: "Acomodacoes",
                column: "FkTipoAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Acomodacoes_ResponsavelIdUsuario",
                table: "Acomodacoes",
                column: "ResponsavelIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkAcomodacao",
                table: "Avaliacoes",
                column: "FkAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkAdministrador",
                table: "Avaliacoes",
                column: "FkAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FkCliente",
                table: "Avaliacoes",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_FkEstabelecimento",
                table: "Contatos",
                column: "FkEstabelecimento");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ResponsavelIdUsuario",
                table: "Contatos",
                column: "ResponsavelIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_FkEndereco",
                table: "Estabelecimentos",
                column: "FkEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AcomodacaoIdAcomodacao",
                table: "Reservas",
                column: "AcomodacaoIdAcomodacao");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkCliente",
                table: "Reservas",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cliente_FkEndereco",
                table: "Usuarios",
                column: "Cliente_FkEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkEndereco",
                table: "Usuarios",
                column: "FkEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Acomodacoes");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "TiposAcomodacoes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
